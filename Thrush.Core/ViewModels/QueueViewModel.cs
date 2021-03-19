﻿using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MediaManager;
using MediaManager.Library;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace Thrush.Core.ViewModels
{
    public class QueueViewModel : BaseViewModel
    {
        private readonly IUserDialogs _userDialogs;
        private readonly IMediaManager _mediaManager;

        public QueueViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService,
                                IUserDialogs userDialogs, IMediaManager mediaManager)
            : base(logProvider, navigationService)
        {
            _userDialogs = userDialogs ?? throw new ArgumentNullException(nameof(userDialogs));
            _mediaManager = mediaManager ?? throw new ArgumentNullException(nameof(mediaManager));
        }

        public MvxObservableCollection<IMediaItem> MediaItems { get; set; } = new MvxObservableCollection<IMediaItem>();

        public string QueueTitle => $"{GetText("Queue")} ({MediaItems?.Count ?? 0})";

        private IMvxAsyncCommand _closeCommand;
        public IMvxAsyncCommand CloseCommand => _closeCommand ?? (_closeCommand = new MvxAsyncCommand(() => Application.Current.MainPage.Navigation.PopModalAsync()));

        public override async Task Initialize()
        {
            IsLoading = true;

            try
            {
                var mediaItems = _mediaManager.Queue;
                if (mediaItems != null)
                {
                    MediaItems.ReplaceWith(mediaItems);
                    await RaisePropertyChanged(nameof(QueueTitle));
                }

            }
            catch (Exception)
            {
            }

            IsLoading = false;
        }

        protected override async Task Play(IMediaItem mediaItem)
        {
            await _mediaManager.PlayQueueItem(mediaItem);
        }
    }
}
