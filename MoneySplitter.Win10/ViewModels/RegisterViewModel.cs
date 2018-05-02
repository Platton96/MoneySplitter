using Caliburn.Micro;
using MoneySplitter.Infrastructure;
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

        private string _laberlForAvatarImage = Defines.Register.BrowseImage.AVATAR;
        private string _labelForBackgroundIamge = Defines.Register.BrowseImage.BACKGROUND;

        private string _confirmPassword;
        private RegisterModel _registerModel;
        private bool _isActiveLoadingProgressRing=false;

        private bool _isErrorVisible = false;
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

        public bool IsActiveLoadingProgressRing
        {
            get { return _isActiveLoadingProgressRing; }
            set
            {
                _isActiveLoadingProgressRing = value;
                NotifyOfPropertyChange(nameof(IsActiveLoadingProgressRing));
            }
        }
        #endregion

        #region Constructor
        public RegisterViewModel(INavigationManager navigationManager, IMembershipService membershipService, IFilePickerService filePickerService)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
            _filePickerService = filePickerService;

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
                    ErrorTitle = Defines.ErrorDetails.Register.ERROR_TITLE,
                    ErrorDescription = Defines.ErrorDetails.Register.ERROR_PASSWORD
                };
                return;
            }

            IsActiveLoadingProgressRing = true;
            var IsSuccessExecution = await _membershipService.ReisterAndLoadUserDataAsync(RegisterModel);
            IsActiveLoadingProgressRing = false;

            if (!IsSuccessExecution)
            {
                IsErrorVisible = true;
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = Defines.ErrorDetails.Register.ERROR_TITLE,
                    ErrorDescription = Defines.ErrorDetails.Register.ERROR_DESCRIPTION
                };
                return;
            }

            _navigationManager.NavigateToShellViewModel();
        }

        public async Task BrowseAvatarImageAsync()
        {
            IsActiveLoadingProgressRing = true;
            var imageResult = await _filePickerService.BrowseImageAsync();
            IsActiveLoadingProgressRing = false;

            RegisterModel.ImageBase64String = imageResult.Base64StringImage;
            LabelForAvatarImage = imageResult.ImageName;
        }

        public async Task BrowseBackgroundImageAsync()
        {
            IsActiveLoadingProgressRing = true;
            var imageResult = await _filePickerService.BrowseImageAsync();
            IsActiveLoadingProgressRing = false;

            RegisterModel.BackgroundImageBase64String = imageResult.Base64StringImage;
            LabelForBackgroundImage = imageResult.ImageName;
        }
        #endregion
    }
}
