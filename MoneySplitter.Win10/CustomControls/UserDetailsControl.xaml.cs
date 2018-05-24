using MoneySplitter.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class UserDetailsControl : UserControl
    {
        public UserModel ViewModel
        {
            get { return (UserModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(UserModel),
            typeof(UserDetailsControl),
            null);

        public UserDetailsControl()
        {
            InitializeComponent();
        }

    }
}
