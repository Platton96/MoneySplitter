using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using MoneySplitter.Models.Session;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class RegisterViewModel : Screen
    {
        #region Fields
        private readonly INavigationManager _navigationManager;
        private readonly IMembershipService _membershipService;
        private readonly IFilePickerService _filePickerService;
        private readonly ILocalizationService _localizationService;

        private string _laberlForAvatarImage;
        private string _labelForBackgroundIamge;

        private string _confirmPassword;
        private RegisterModel _registerModel;
        private bool _isLoading;

        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;
        #endregion

        #region Properties
        public RegisterModel RegisterModel
        {
            get { return _registerModel; }
            set
            {
                _registerModel = value;
                NotifyOfPropertyChange(nameof(RegisterModel));
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyOfPropertyChange(nameof(ConfirmPassword));
            }
        }

        public string LabelForAvatarImage
        {
            get { return _laberlForAvatarImage; }
            set
            {
                _laberlForAvatarImage = value;
                NotifyOfPropertyChange(nameof(LabelForAvatarImage));
            }
        }

        public string LabelForBackgroundImage
        {
            get { return _labelForBackgroundIamge; }
            set
            {
                _labelForBackgroundIamge = value;
                NotifyOfPropertyChange(nameof(LabelForBackgroundImage));
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

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }
        #endregion

        #region Constructor
        public RegisterViewModel(
            INavigationManager navigationManager,
            IMembershipService membershipService, 
            IFilePickerService filePickerService,
            ILocalizationService localizationService)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
            _filePickerService = filePickerService;
            _localizationService = localizationService;

            InitializeField();

            RegisterModel = new RegisterModel();
        }
        #endregion

        #region Public methods
        public async Task Register()
        {
            IsErrorVisible = false;

            if (RegisterModel.Password != ConfirmPassword)
            {
                IsErrorVisible = true;
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.REGISTER_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.REGISTER_ERROR_PASSWORD)
                };
                return;
            }

            IsLoading = true;
            var IsSuccessExecution = await _membershipService.ReisterAndLoadUserDataAsync(RegisterModel);
            IsLoading = false;

            if (!IsSuccessExecution)
            {
                IsErrorVisible = true;
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.REGISTER_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.REGISTER_ERROR_TITLE)
                };
                return;
            }

            _navigationManager.NavigateToShellViewModel();
        }

        private void InitializeField()
        {
            _laberlForAvatarImage = _localizationService.GetString(Texts.AVATAR_IMAGE_TEXTBLOCK_TEXT);
            _labelForBackgroundIamge = _localizationService.GetString(Texts.REGISTER_ERROR_DESCRIPTION);
        }

        public async Task BrowseAvatarImageAsync()
        {
            IsLoading = true;
            var imageResult = await _filePickerService.BrowseImageAsync();
            IsLoading = false;

            RegisterModel.ImageBase64String = imageResult.Base64StringImage;
            LabelForAvatarImage = imageResult.ImageName;
        }

        public async Task BrowseBackgroundImageAsync()
        {
            IsLoading = true;
            var imageResult = await _filePickerService.BrowseImageAsync();
            IsLoading = false;

            RegisterModel.BackgroundImageBase64String = imageResult.Base64StringImage;
            LabelForBackgroundImage = imageResult.ImageName;
        }
        #endregion
    }
}
