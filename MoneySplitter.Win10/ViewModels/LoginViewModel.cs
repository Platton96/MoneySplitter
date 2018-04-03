using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel:Screen
    {
        private readonly INavigationManager _navigationManager;
        private IMembershipService _membershipService;

        private string _email="q@mail.ru";
        private string _password="123";

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

        public void GoToRegistretion()
        {
            _navigationManager.NavigateToRegistrViewModel();
        }
    }
}
