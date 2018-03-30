using Caliburn.Micro;
using MoneySplitter.Models;
using MoneySplitter.Infrastructure;

namespace MoneySplitter.Win10.ViewModels
{
    public class ShellViewModel : Screen
    {
        private IMembershipService _membershipService;

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

        public ShellViewModel(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            UserModel = _membershipService.CurrentUser;
        }
    }
}
