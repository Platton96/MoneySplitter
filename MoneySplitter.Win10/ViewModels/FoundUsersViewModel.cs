using Caliburn.Micro;
using Windows.UI.Xaml;

namespace MoneySplitter.Win10.ViewModels
{
    public class FoundUsersViewModel : Screen
    {
        private string _qeury;
        private bool _isActiveTextBox;
        private readonly DispatcherTimer _timer;

        public FoundUsersViewModel()
        {
            _timer=new DispatcherTimer();
        }

        public string Qeury
        {
            get { return _qeury; }
            set
            {
                _qeury = value;
                NotifyOfPropertyChange(nameof(Qeury));
            }
        }

        public bool IsActiveTextBox
        {
            get { return _isActiveTextBox; }
            set
            {
                _isActiveTextBox = value;
                NotifyOfPropertyChange(nameof(IsActiveTextBox));
            }
        }

        protected override void OnActivate()
        {

            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }


    }
}
