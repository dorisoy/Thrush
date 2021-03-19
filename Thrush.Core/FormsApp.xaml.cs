﻿#if RELEASE
using Thrush.Services;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
#endif
using Xamarin.Forms;
using FormsDevice = Xamarin.Forms.Device;

namespace Thrush.Core
{
    public partial class FormsApp : Application
    {
        public FormsApp()
        {
            InitializeComponent();

            FormsDevice.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental",
                "SwipeView_Experimental"
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
#if RELEASE
            AppCenter.Start($"android={AppSettings.AndroidAppcenterSecret}; uwp={AppSettings.UwpAppcenterSecret}; ios={AppSettings.IosAppcenterSecret}",
                  typeof(Analytics), typeof(Crashes));
#endif
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
