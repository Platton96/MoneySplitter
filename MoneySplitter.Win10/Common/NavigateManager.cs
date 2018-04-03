using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Win10.ViewModels;
using System;
using Windows.UI.Core;

namespace MoneySplitter.Win10.Common
{
    public class NavigationManager : INavigationManager
    {
        public INavigationService WindowNavigationService { get; private set; }
        public INavigationService ShellNavigationService { get; private set; }

        public NavigationManager(INavigationService navigationService)
        {
            WindowNavigationService = navigationService;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            WindowNavigationService.GoBack();
        }

        public void NavigateToShellView()
        {
            WindowNavigationService.NavigateToViewModel<ShellViewModel>();
        }
        public void NavigateToRegistrViewModel()
        {
            WindowNavigationService.NavigateToViewModel<RegistrViewModel>();
        }

        public void InitializeShellNavigationService(INavigationService navigationService)
        {
            ShellNavigationService = navigationService;
        }

        public void InitializeShellNavigationService(object navigationService)
        {
            ShellNavigationService = (INavigationService)navigationService;
        }

        public void NavigateToShellViewModel()
        {
            ShellNavigationService.NavigateToViewModel<HelloWorldViewModel>();
        }

        public void NavigateToFriendsViewModelFrame()
        {
            ShellNavigationService.NavigateToViewModel<FriendsViewModel>();
        }

        public void NavigateToShellViewModel(Type viewModelType)
        {
            ShellNavigationService.NavigateToViewModel(viewModelType);
        }
    }

}
