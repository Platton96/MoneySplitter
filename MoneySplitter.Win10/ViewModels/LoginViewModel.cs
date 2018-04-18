﻿using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel:Screen
    {
        private readonly INavigationManager _navigationManager;
        private IMembershipService _membershipService;
        private IFriendsManager _friendsManager;

        private const string DEFAULT_USER_LOGIN = "ivan_17@epam.com";
        private const string DEFAULT_USER_PASSWORD = "1234abcd";

        private string _email = DEFAULT_USER_LOGIN; 
        private string _password = DEFAULT_USER_PASSWORD;

        private bool _isActiveLoadingProgressRing=false;
        private bool _isVisableStackPanel = true;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(nameof(Email));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(nameof(Password));
            }
        }

        public bool IsActiveLoadingProgressRing
        {
            get { return _isActiveLoadingProgressRing; }
            set
            {
                _isActiveLoadingProgressRing = value;
                NotifyOfPropertyChange(nameof(IsActiveLoadingProgressRing));
            }
        }

        public bool IsVisableStackPanel
        {
            get { return _isVisableStackPanel; }
            set
            {
                _isVisableStackPanel = value;
                NotifyOfPropertyChange(nameof(IsVisableStackPanel));
            }
        }

        public LoginViewModel( INavigationManager navigationManager, IMembershipService membershipService, IFriendsManager friendsManager)
        {
            _navigationManager = navigationManager;
            _membershipService = membershipService;
            _friendsManager = friendsManager;
        }

        public async Task SignInAsync()
        {
            IsActiveLoadingProgressRing = true;
            IsVisableStackPanel = false;
            await _membershipService.SingInAndLoadUserDataAsync(Email, Password);
            IsActiveLoadingProgressRing = false;

            await _friendsManager.LoadUserFriendsAsync();

            var userModel = _membershipService.CurrentUser;

            if (userModel != null)
            {
                _navigationManager.NavigateToShellViewModel();
            }
        }

        public void NavigateToRegister()
        {
            _navigationManager.NavigateToRegisterViewModel();
        }
    }
}
