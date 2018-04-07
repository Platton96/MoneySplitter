using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel:Screen
    {
        private readonly INavigationManager _navigationManager;
        private IMembershipService _membershipService;

        private const string DEFAULT_USER_LOGIN = "q@mail.ru";
        private const string DEFAULT_USER_PASSWORD = "123";

        private string _email = DEFAULT_USER_LOGIN; 
        private string _password = DEFAULT_USER_PASSWORD;

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
            await _membershipService.SingInAndLoadUserDataAsync(Email, Password);
            var userModel = _membershipService.CurrentUser;

            if (userModel != null)
            {
                _navigationManager.NavigateToShellView();
            }
        }

        public void NavigateToRegistretion()
        {
            _navigationManager.NavigateToRegisterViewModel();
        }
    }
}
