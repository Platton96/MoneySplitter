using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.Session;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public  class RegisterViewModel : Screen
    {
        private readonly INavigationManager _navigationManager;
        private readonly IMembershipService _membershipService;

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

                _navigationManager.NavigateToShellView();
            }
        }
    }
}
