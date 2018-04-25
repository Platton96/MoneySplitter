using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.Session;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private readonly INavigationManager _navigationManager;
        private readonly IMembershipService _membershipService;
        private readonly IFilePickerService _filePickerService;

        private const string DEFEALT_TEXT_LABEL_AVATAR = "Browse avatar image";
        private const string DEFEALT_TEXT_LABEL_BACKGROUND = "Browse background image";

        private string _laberlForAvatarImage = DEFEALT_TEXT_LABEL_AVATAR;
        private string _labelForBackgroundIamge = DEFEALT_TEXT_LABEL_BACKGROUND;

        private string _confirmPassword;
        private RegisterModel _registerModel;
        private bool _isActiveLoadingProgressRing=false;

        private bool _isIssueVisibility = false;
        private string _issueTitle = Defines.Issue.Login.IssueTitle;
        private string _issueMessage = Defines.Issue.Login.IssueMessage;

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

        public RegisterViewModel(INavigationManager navigationManager, IMembershipService membershipService, IFilePickerService filePickerService)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
            _filePickerService = filePickerService;

            RegisterModel = new RegisterModel();
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

        public async Task Register()
        {
            if (RegisterModel.Password != ConfirmPassword)
            {
                return;
            }
            else
            {
                IsActiveLoadingProgressRing = true;
                await _membershipService.ReisterAndLoadUserDataAsync(RegisterModel);
                IsActiveLoadingProgressRing = false;

                var userModel = _membershipService.CurrentUser;

                _navigationManager.NavigateToShellViewModel();
            }
        }

        public async Task BrowseAvatarImageAsync()
        {
            var imageResult = await _filePickerService.BrowseImageAsync();

            RegisterModel.ImageBase64String = imageResult.Base64StringImage;
            LabelForAvatarImage = imageResult.ImageName;
        }

        public async Task BrowseBackgroundImageAsync()
        {
            var imageResult = await _filePickerService.BrowseImageAsync();

            RegisterModel.BackgroundImageBase64String = imageResult.Base64StringImage;
            LabelForBackgroundImage = imageResult.ImageName;
        }

    }
}
