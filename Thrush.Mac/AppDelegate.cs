﻿using Thrush.Core;
using Foundation;
using MediaManager;
using MvvmCross.Forms.Platforms.Mac.Core;
using Xamarin.Forms;

namespace Thrush.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<MvxFormsMacSetup<Core.App, FormsApp>, Core.App, FormsApp>
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.SetFlags("CollectionView_Experimental");
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            CrossMediaManager.Current.Init();
            base.DidFinishLaunching(notification);
        }
    }
}
