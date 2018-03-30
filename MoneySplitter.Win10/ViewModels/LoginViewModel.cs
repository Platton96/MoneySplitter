using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Services;
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(nameof(Password));
            }
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
