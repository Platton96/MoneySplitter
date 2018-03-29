using Caliburn.Micro;
using MoneySplitter.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class LoginViewModel:Screen
    {
        private LoginModel _login;
        public LoginModel Login
        {
            get { return _login; }
            set
            {
                _login = value;
                NotifyOfPropertyChange(nameof(LoginModel));
            }
        }



    }
}
