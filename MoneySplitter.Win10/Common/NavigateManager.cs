using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
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

        public void NavigateToShellView()
        {
            _windowNavigationService.NavigateToViewModel<ShellViewModel>();
        }
        public void NavigateToRegistrViewModel()
        {
            _windowNavigationService.NavigateToViewModel<RegistrViewModel>();
        }

        public void InitializeShellNavigationService(INavigationService navigationService)
        {
            _shellNavigationService = navigationService;
        }
    }

}
