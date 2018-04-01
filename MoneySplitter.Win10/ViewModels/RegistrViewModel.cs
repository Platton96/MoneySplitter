using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.Session;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public  class RegistrViewModel : Screen
    {
        private readonly INavigationManager _navigationManager;
        private readonly IMembershipService _membershipService;

        private RegistrModel _registrModel;

        private string _confirmPassword;

        public RegistrViewModel(INavigationManager navigationManager, IMembershipService membershipService)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
        }

        public RegistrModel RegistrModel
        {
            get { return _registrModel; }
            set
            {
                _registrModel = value;
                NotifyOfPropertyChange(nameof(RegistrModel));
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

        public async Task Registred()
        {
            if (RegistrModel.Password != ConfirmPassword)
            {
                //Passwor!=confirmPassword
                return;
            }
            else
            {
                await _membershipService.ReistrAndLoadUserDataAsync(RegistrModel);

                var userModel = _membershipService.CurrentUser;

                _navigationManager.NavigateToShellView();
            }
        }
    }
}
