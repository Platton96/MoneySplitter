using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.App;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel : Screen
    {
        #region Fields
        private readonly INavigationManager _navigationManager;
        private IMembershipService _membershipService;
        private IFriendsManager _friendsManager;

        private const string DEFAULT_USER_LOGIN = "ivan_17@epam.com";
        private const string DEFAULT_USER_PASSWORD = "1234abcd";

        private string _email = DEFAULT_USER_LOGIN;
        private string _password = DEFAULT_USER_PASSWORD;

        private bool _isActiveLoadingProgressRing = false;

        private bool _isIssueVisibility = false;
        private string _issueTitle = Defines.Issue.Login.ISSUE_TITLE;
        private string _issueMessage = Defines.Issue.Login.ISSUE_MESSAGE;
        #endregion

        #region Properties
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

        public bool IsIssueVisibility
        {
            get { return _isIssueVisibility; }
            set
            {
                _isIssueVisibility = value;
                NotifyOfPropertyChange(nameof(IsIssueVisibility));
            }
        }

        public string IssueTitle
        {
            get { return _issueTitle; }
            set
            {
                _issueTitle = value;
                NotifyOfPropertyChange(nameof(IssueTitle));
            }
        }

        public string IssueMessage
        {
            get { return _issueMessage; }
            set
            {
                _issueMessage = value;
                NotifyOfPropertyChange(nameof(IssueMessage));
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel(INavigationManager navigationManager, IMembershipService membershipService, IFriendsManager friendsManager)
        {
            _navigationManager = navigationManager;
            _membershipService = membershipService;
            _friendsManager = friendsManager;
        }
        #endregion

        #region Public methods
        public async Task SignInAsync()
        {
            IsActiveLoadingProgressRing = true;
            IsIssueVisibility = false;

            var IsSuccessExecution=await _membershipService.SingInAndLoadUserDataAsync(Email, Password);
            IsActiveLoadingProgressRing = false;
            if (IsSuccessExecution)
            {
                await _friendsManager.LoadUserFriendsAsync();
                var userModel = _membershipService.CurrentUser;
                _navigationManager.NavigateToShellViewModel();
            }
            else
            {
                IsIssueVisibility = true;
            }

        }

        public void NavigateToRegister()
        {
            _navigationManager.NavigateToRegisterViewModel();
        }
        #endregion
    }
}
