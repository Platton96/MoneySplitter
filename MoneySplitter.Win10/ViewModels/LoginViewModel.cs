using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Services;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel:Screen
    {
        private readonly INavigationManager _navigationManager;
        private IMembershipService _membershipService;

        private string _email;
        private string _password;

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


        public LoginViewModel( INavigationManager navigationManager, IMembershipService membershipService)
        {
            _navigationManager = navigationManager;
            _membershipService = membershipService;
        }

        public async Task SignInAsync()
        {
            await _membershipService.LoadUserData(Email, Password);
            var user = _membershipService.CurrentUser;

            if (user != null)
            {
                _navigationManager.NavigateToShellView(user);
            }
        }

    }
}
