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

        private RegisterModel _registrModel;

        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _name;
        private string _surname;
        private int _phoneNumber;
        private int _creditCardNumber;

        public RegistrViewModel(INavigationManager navigationManager, IMembershipService membershipService)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
        }

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

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyOfPropertyChange(nameof(ConfirmPassword));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                NotifyOfPropertyChange(nameof(Surname));
            }
        }

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(nameof(PhoneNumber));
            }
        }

        public int CreditCardNumber
        {
            get { return _creditCardNumber; }
            set
            {
                _creditCardNumber = value;
                NotifyOfPropertyChange(nameof(CreditCardNumber));
            }
        }





        public async Task Registred()
        {
            if (Password != ConfirmPassword)
            {
                //Passwor!=confirmPassword
                return;
            }
            else
            {
                var registerModel = new RegisterModel
                {
                    Email = this.Email,
                    Name = this.Name,
                    Password = this.Password,
                    Surname = this.Surname,
                    PhoneNumber = this.PhoneNumber,
                    CreditCardNumber = this.CreditCardNumber

                };
                await _membershipService.ReistrAndLoadUserDataAsync(registerModel);

                var userModel = _membershipService.CurrentUser;

                _navigationManager.NavigateToShellView();
            }
        }
    }
}
