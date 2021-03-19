﻿using System.Collections.Generic;
using System.Reflection;
using Acr.UserDialogs;
using AndroidX.AppCompat.Widget;
using Thrush.Core;
using Thrush.Core.Helpers;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android;
using Google.Android.Material.TextField;
using Google.Android.Material.BottomNavigation;

namespace Thrush.Droid
{
    public class Setup : MvxFormsAndroidSetup<App, FormsApp>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            UserDialogs.Init(() => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
            ActionSheetConfig.DefaultAndroidStyleId = Resource.Style.MainTheme_BottomSheet;
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IThemeService, ThemeService>();
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(BottomNavigationView).Assembly
            };
    }
}
