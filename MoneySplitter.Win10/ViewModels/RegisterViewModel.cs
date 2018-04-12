using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.Session;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using System;

namespace MoneySplitter.Win10.ViewModels
{
    public  class RegisterViewModel : Screen
    {
        private readonly INavigationManager _navigationManager;
        private readonly IMembershipService _membershipService;

        private const string DEFEALT_TEXT_LABEL_AVATAR = "Browse avatar image";
        private const string DEFEALT_TEXT_LABEL_BACKGROUND = "Browse background image";

        private string _laberlForAvatarImage = DEFEALT_TEXT_LABEL_AVATAR;
        private string _labelForBackgroundIamge = DEFEALT_TEXT_LABEL_BACKGROUND;

        private string _confirmPassword;
        private RegisterModel _registerModel;

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

        public RegisterViewModel(INavigationManager navigationManager, IMembershipService membershipService)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;

            RegisterModel = new RegisterModel();
        }
        
        public async Task Register()
        {
            if (RegisterModel.Password != ConfirmPassword)
            {
                return;
            }
            else
            {
                await _membershipService.ReisterAndLoadUserDataAsync(RegisterModel);

                var userModel = _membershipService.CurrentUser;

                _navigationManager.NavigateToShellViewModel();
            }
        }

        public async Task<string> BrowseImageAsync( )
        {
            var picker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };

            picker.FileTypeFilter.Add(Defines.ImageExtension.JPG);
            picker.FileTypeFilter.Add(Defines.ImageExtension.JPEG);
            picker.FileTypeFilter.Add(Defines.ImageExtension.PNG);

            var file = await picker.PickSingleFileAsync();

            return file != null ? "Picked photo: " + file.Name : "Operation cancelled.";

        }
    }
}
