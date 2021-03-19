﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;

namespace Thrush.Core.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        public RootViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
        }

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }

        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>();
            tasks.Add(NavigationService.Navigate<HomeViewModel>());
            tasks.Add(NavigationService.Navigate<BrowseViewModel>());
            tasks.Add(NavigationService.Navigate<SettingsViewModel>());
            await Task.WhenAll(tasks);
        }
    }
}
