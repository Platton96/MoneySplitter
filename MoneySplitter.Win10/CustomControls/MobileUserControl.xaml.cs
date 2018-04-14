using MoneySplitter.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class MobileUserControl : UserControl
    {
        public event EventHandler<UserModel> OnAddOrRemoveItemClick;

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

        public string ButtonContent
        {
            get { return (string)GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }

        public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register(
            "ButtonContent",
            typeof(string),
            typeof(MobileUserControl),
            null);

        public MobileUserControl()
        {
            InitializeComponent();
        }

        private void OnAddOrRemoveButtonClick(object sender, RoutedEventArgs e)
        {
            OnAddOrRemoveItemClick?.Invoke(this, ViewModel);
        }
    }
}
