using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace MoneySplitter.Win10.Common
{
    public class NavigationManager : INavigationManager
    {
        private readonly INavigationService _navigationService;

        public NavigationManager(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested; ;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            _navigationService.GoBack();
        }

        public void NavigateToShellView(UserModel user)
        {
            _navigationService.NavigateToViewModel<ShellViewModel>(user);
        }
    }

}
