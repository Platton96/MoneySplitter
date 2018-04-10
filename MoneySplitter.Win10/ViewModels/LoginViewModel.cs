using Caliburn.Micro;
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

        public LoginViewModel( INavigationManager navigationManager, IMembershipService membershipService, IFriendsManager friendsManager)
        {
            _navigationManager = navigationManager;
            _membershipService = membershipService;
            _friendsManager = friendsManager;
        }

        public async Task SignInAsync()
        {
            await _membershipService.SingInAndLoadUserDataAsync(Email, Password);
            await _friendsManager.LoadFriendsOfCurrentUserAsync();

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
