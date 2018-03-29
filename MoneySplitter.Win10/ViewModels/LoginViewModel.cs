using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.Session;
using MoneySplitter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel:Screen
    {
        private readonly INavigationManager _navigationManager;
        private MembershipService _membershipService;

        public LoginViewModel( INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _membershipService = new MembershipService();
        }

        private LoginModel _login;
        public LoginModel Login
        {
            get { return _login; }
            set
            {
                _login = value;
                NotifyOfPropertyChange(nameof(LoginModel));
            }
        }

        public async void SignIn()
        {
            await _membershipService.LoadUserData(Login);
            var user = _membershipService.CurrentUser;

            if(user!=null)
                _navigationManager.NavigateToShellView(user);
        }


    }
}
