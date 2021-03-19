﻿using System.ComponentModel;
using Thrush.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace Thrush.Core.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class SettingsPlaybackPage : MvxContentPage<SettingsPlaybackViewModel>
    {
        public SettingsPlaybackPage()
        {
            InitializeComponent();
        }
    }
}
