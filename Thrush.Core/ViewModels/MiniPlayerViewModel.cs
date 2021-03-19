﻿using System;
using System.Threading.Tasks;
using MediaManager;
using MediaManager.Library;
using MediaManager.Player;
using MediaManager.Queue;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using Xamarin.Forms;

namespace Thrush.Core.ViewModels
{
    public class MiniPlayerViewModel : BaseViewModel
    {
        public IMediaManager MediaManager { get; }

        public MiniPlayerViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMediaManager mediaManager)
            : base(logProvider, navigationService)
        {
            MediaManager = mediaManager ?? throw new ArgumentNullException(nameof(mediaManager));
            MediaManager.StateChanged += MediaManager_StateChanged;
            MediaManager.PositionChanged += MediaManager_PositionChanged;
            mediaManager.MediaItemChanged += MediaManager_MediaItemChanged;
        }

        private void MediaManager_MediaItemChanged(object sender, MediaManager.Media.MediaItemEventArgs e)
        {
            //TODO: this is not triggered
            RaisePropertyChanged(nameof(CurrentMediaItem));
        }

        public bool IsVisible => MediaManager.State != MediaPlayerState.Stopped;

        private void MediaManager_StateChanged(object sender, MediaManager.Playback.StateChangedEventArgs e)
        {
            if (MediaManager.IsPlaying())
                PlayPauseImage = ImageSource.FromFile("playback_controls_pause_button.png");
            else
                PlayPauseImage = ImageSource.FromFile("playback_controls_play_button.png");

            RaisePropertyChanged(nameof(CurrentMediaItemText));

            Progress = MediaManager.Position.TotalSeconds / MediaManager.Duration.TotalSeconds;

            RaisePropertyChanged(nameof(IsVisible));
            RaisePropertyChanged(nameof(CurrentMediaItem));
        }

        private ImageSource _playPauseImage = "playback_controls_pause_button.png";
        public ImageSource PlayPauseImage
        {
            get => _playPauseImage;
            set => SetProperty(ref _playPauseImage, value);
        }

        private ImageSource _shuffleImage = ImageSource.FromFile("playback_controls_shuffle_off.png");
        public ImageSource ShuffleImage
        {
            get => _shuffleImage;
            set => SetProperty(ref _shuffleImage, value);
        }

        private FormattedString _currentMediaItemText;
        public FormattedString CurrentMediaItemText
        {
            get
            {
                var currentMediaItemText = new FormattedString();
                if (MediaManager.Queue.Current != null)
                {
                    currentMediaItemText.Spans.Add(new Span { Text = MediaManager.Queue.Current.DisplayTitle, FontAttributes = FontAttributes.Bold, FontSize = 12 });
                    currentMediaItemText.Spans.Add(new Span { Text = " • " });
                    currentMediaItemText.Spans.Add(new Span { Text = MediaManager.Queue.Current.DisplaySubtitle, FontSize = 12 });
                }
                else
                    currentMediaItemText.Spans.Add(new Span { Text = "CHAMELEON" });

                _currentMediaItemText = currentMediaItemText;
                return currentMediaItemText;
            }
            set => SetProperty(ref _currentMediaItemText, value);
        }

        private double _progress;
        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        public IMediaItem CurrentMediaItem => MediaManager.Queue.Current;

        private IMvxAsyncCommand _playpauseCommand;
        public IMvxAsyncCommand PlayPauseCommand => _playpauseCommand ?? (_playpauseCommand = new MvxAsyncCommand(PlayPause));

        private IMvxCommand _shuffleCommand;
        public IMvxCommand ShuffleCommand => _shuffleCommand ?? (_shuffleCommand = new MvxCommand(Shuffle));

        private IMvxAsyncCommand _previousCommand;
        public IMvxAsyncCommand PreviousCommand => _previousCommand ?? (_previousCommand = new MvxAsyncCommand(PlayPrevious));

        private IMvxAsyncCommand _nextCommand;
        public IMvxAsyncCommand NextCommand => _nextCommand ?? (_nextCommand = new MvxAsyncCommand(PlayNext));

        private IMvxAsyncCommand _openPlayerCommand;
        public IMvxAsyncCommand OpenPlayerCommand => _openPlayerCommand ?? (_openPlayerCommand = new MvxAsyncCommand(OpenPlayer));

        private void MediaManager_PositionChanged(object sender, MediaManager.Playback.PositionChangedEventArgs e)
        {
            Progress = e.Position.TotalSeconds / MediaManager.Duration.TotalSeconds;
        }

        private async Task PlayPause()
        {
            if (MediaManager.IsPlaying())
                PlayPauseImage = ImageSource.FromFile("playback_controls_play_button.png");
            else
                PlayPauseImage = ImageSource.FromFile("playback_controls_pause_button.png");

            await MediaManager.PlayPause();
        }

        private void Shuffle()
        {
            MediaManager.ToggleShuffle();
            switch (MediaManager.ShuffleMode)
            {
                case ShuffleMode.Off:
                    ShuffleImage = ImageSource.FromFile("playback_controls_shuffle_off.png");
                    break;
                case ShuffleMode.All:
                    ShuffleImage = ImageSource.FromFile("playback_controls_shuffle_on.png");
                    break;
            }
        }

        private async Task PlayPrevious()
        {
            await MediaManager.PlayPrevious();
            await RaisePropertyChanged(nameof(CurrentMediaItemText));
            PlayPauseImage = ImageSource.FromFile("playback_controls_pause_button.png");
        }

        private async Task PlayNext()
        {
            await MediaManager.PlayNext();
            await RaisePropertyChanged(nameof(CurrentMediaItemText));
            PlayPauseImage = ImageSource.FromFile("playback_controls_pause_button.png");
        }

        private async Task OpenPlayer()
        {
            await NavigationService.Navigate<PlayerViewModel>();
        }
    }
}
