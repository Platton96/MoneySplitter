using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel : Screen
    {
        #region Fields
        private readonly INavigationManager _navigationManager;
        private readonly IMembershipService _membershipService;
        private readonly ILocalizationService _localizationService;

        private const string DEFAULT_USER_LOGIN = "vlad_nagibator12@mail.ru";
        private const string DEFAULT_USER_PASSWORD = "1234abcd";

        private string _email = DEFAULT_USER_LOGIN;
        private string _password = DEFAULT_USER_PASSWORD;

        private bool _isLoading;

        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;
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

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }

        public bool IsErrorVisible
        {
            get { return _isErrorVisible; }
            set
            {
                _isErrorVisible = value;
                NotifyOfPropertyChange(nameof(IsErrorVisible));
            }
        }

        public ErrorDetailsModel ErrorDetailsModel
        {
            get { return _errorDetailsModel; }
            set
            {
                _errorDetailsModel = value;
                NotifyOfPropertyChange(nameof(ErrorDetailsModel));
            }
        }

        #endregion

        #region Constructor
        public LoginViewModel(
            INavigationManager navigationManager,
            IMembershipService membershipService,
            ILocalizationService localizationService)
        {
            _navigationManager = navigationManager;
            _membershipService = membershipService;
            _localizationService = localizationService;
        }
        #endregion

        #region Public methods
        public async Task SignInAsync()
        {
            IsLoading = true;
            IsErrorVisible = false;

            var isSuccessExecution = await _membershipService.SingInAndLoadUserDataAsync(Email, Password);

            IsLoading = false;

            if (!isSuccessExecution)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.LOGIN_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.LOGIN_ERROR_DESCRIPTION)
                };

                IsErrorVisible = true;
                return;
            }

            _navigationManager.NavigateToShellViewModel();
        }

        public void NavigateToRegister()
        {
            _navigationManager.NavigateToRegisterViewModel();
        }
        #endregion

        protected override async void OnViewReady(object view)
        {
            base.OnActivate();
            try
            {
                if (await _membershipService.TryLoadUserFromDbAsync())
                {
                    _navigationManager.NavigateToShellViewModel();
                }
            }

            catch
            {
                await _membershipService.InitializeDbAsyns();
            }
        }
    }
}
