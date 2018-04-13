using MoneySplitter.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class MobileUserControl : UserControl
    {
        public event EventHandler<UserModel> OnRemoveItemClick;

        public UserModel ViewModel
        {
            get { return (UserModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(UserModel),
            typeof(MobileUserControl),
            null);

        public MobileUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveItemClick?.Invoke(this, ViewModel);
        }
    }
}
