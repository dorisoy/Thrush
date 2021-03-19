﻿using MediaManager;
using MediaManager.Library;
using Xamarin.Forms;

namespace Thrush.Core.Templates
{
    public class ContentItemTemplateSelector : DataTemplateSelector
    {
        IMediaManager MediaManager => CrossMediaManager.Current;

        public DataTemplate CurrentMediaItemTemplate { get; set; } = new CurrentMediaItemTemplate();
        public DataTemplate VerticalMediaItemTemplate { get; set; } = new VerticalMediaItemTemplate();
        public DataTemplate HorizontalMediaItemTemplate { get; set; } = new HorizontalMediaItemTemplate();
        public DataTemplate VerticalPlaylistTemplate { get; set; } = new VerticalPlaylistTemplate();
        public DataTemplate HorizontalPlaylistTemplate { get; set; } = new HorizontalPlaylistItemTemplate();

        public virtual bool Horizontal => false;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case IMediaItem mediaItem:
                    if (Horizontal)
                        return HorizontalMediaItemTemplate;
                    else if (ReferenceEquals(mediaItem, MediaManager.Queue.Current))
                        return CurrentMediaItemTemplate;
                    else
                        return VerticalMediaItemTemplate;
                case IPlaylist _:
                    if (Horizontal)
                        return HorizontalPlaylistTemplate;
                    else
                        return VerticalPlaylistTemplate;
                default:
                    return VerticalMediaItemTemplate;
            }
        }
    }
}
