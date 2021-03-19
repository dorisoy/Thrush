﻿using System;
using System.Globalization;
using MediaManager.Library;
using MvvmCross.Converters;

namespace Thrush.Core.Converters
{
    public class PlaylistTimeValueConverter : MvxValueConverter<IPlaylist, string>
    {
        protected override string Convert(IPlaylist value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.TotalTime.Hours > 2)
            {
                return $"{value.TotalTime.Hours} hours " + $" { value.TotalTime.Minutes} minutes";
            }
            if (value.TotalTime.Hours > 1)
            {
                return $"{value.TotalTime.Hours} hour " + $" { value.TotalTime.Minutes} minutes";
            }
            return $" { value.TotalTime.Minutes} minutes";
        }
    }
}
