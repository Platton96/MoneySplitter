using Caliburn.Micro;
using MoneySplitter.Models;

namespace MoneySplitter.Win10.ViewModels
{
    public class ShellViewModel : Screen
    {
        private UserModel _user;

        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                NotifyOfPropertyChange(nameof(User));
            }
        }

        public UserModel Parameter { get; set; }

        protected override void OnActivate()
        {
            base.OnActivate();
            User = Parameter;
        }
    }
}
