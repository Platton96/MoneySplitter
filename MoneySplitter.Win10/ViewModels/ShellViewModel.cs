using Caliburn.Micro;
using MoneySplitter.Models;
using MoneySplitter.Infrastructure;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.ViewModels
{
    public class ShellViewModel : Screen
    {
        private IMembershipService _membershipService;
        private readonly INavigationManager _navigationManager;

        private UserModel _userModel;

        public UserModel UserModel
        {
            get { return _userModel; }
            set
            {
                _userModel = value;
                NotifyOfPropertyChange(nameof(UserModel));
            }
        }

        public ShellViewModel(IMembershipService membershipService, INavigationManager navigationManager)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
        }

        public void InitializeShellNavigationService(Frame frame)
        {
            _navigationManager.InitializeShellNavigationService(new FrameAdapter(frame));

            _navigationManager.NavigateShellViewModel();
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            UserModel = _membershipService.CurrentUser;
        }
    }
}
