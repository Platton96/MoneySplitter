using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Win10.ViewModels;
using System;
using Windows.UI.Core;

namespace MoneySplitter.Win10.Common
{
    public class NavigationManager : INavigationManager
    {
        private readonly INavigationService _windowNavigationService;
        private INavigationService _shellNavigationService;

        public NavigationManager(INavigationService navigationService)
        {
            _windowNavigationService = navigationService;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            _windowNavigationService.GoBack();
        }

        public void NavigateToShellViewModel()
        {
            _windowNavigationService.NavigateToViewModel<ShellViewModel>();
        }

        public void NavigateToRegisterViewModel()
        {
            _windowNavigationService.NavigateToViewModel<RegisterViewModel>();
        }

        public void InitializeShellNavigationService(INavigationService navigationService)
        {
            _shellNavigationService = navigationService;
        }

        public void InitializeShellNavigationService(object navigationService)
        {
            _shellNavigationService = (INavigationService)navigationService;
        }

        public void NavigateToMainPage()
        {
            _shellNavigationService.NavigateToViewModel<HelloWorldViewModel>();
        }

        public void NavigateToFriends()
        {
            _shellNavigationService.NavigateToViewModel<FriendsViewModel>();
        }

        public void NavigateToShellViewModel(Type viewModelType)
        {
            _shellNavigationService.NavigateToViewModel(viewModelType);
        }

        public void NavigateToFoundUsersViewModel()
        {
            _shellNavigationService.NavigateToViewModel<FoundUsersViewModel>();
        }
    }
}
