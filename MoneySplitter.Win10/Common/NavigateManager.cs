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

        public event EventHandler OnShellNavigationManagerNavigated;

        public NavigationManager(INavigationService navigationService)
        {
            _windowNavigationService = navigationService;

        }

        public void NavigateToShellViewModel()
        {
            _windowNavigationService.NavigateToViewModel<ShellViewModel>();
        }

        public void NavigateToRegisterViewModel()
        {
            _windowNavigationService.NavigateToViewModel<RegisterViewModel>();
        }

        private void OnShellNavigationServiceNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            OnShellNavigationManagerNavigated?.Invoke(this, null);
        }

        public void InitializeShellNavigationService(object navigationService)
        {
            _shellNavigationService = (INavigationService)navigationService;
            _shellNavigationService.Navigated += OnShellNavigationServiceNavigated;
        }

        public void NavigateToMainPage()
        {
            _shellNavigationService.NavigateToViewModel<HelloWorldViewModel>();
        }

        public void NavigateToFriends()
        {
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            _shellNavigationService.NavigateToViewModel<FriendsViewModel>();
        }

        public void NavigateToShellViewModel(Type viewModelType)
        {
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            _shellNavigationService.NavigateToViewModel(viewModelType);
        }

        public void NavigateToFoundUsersViewModel()
        {
            SetBackButtonVisibility(_shellNavigationService.CanGoBack);
            _shellNavigationService.NavigateToViewModel<FoundUsersViewModel>();
        }

        private void SetBackButtonVisibility(bool value)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = value ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        public void GoBack()
        {
            if (_shellNavigationService.CanGoBack)
            {
                _shellNavigationService.GoBack();
            }
        }
    }
}
