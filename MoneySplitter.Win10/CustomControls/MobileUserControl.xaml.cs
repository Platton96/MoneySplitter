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
            get => (UserModel)GetValue(ViewModelProperty); 
            set { SetValue(ViewModelProperty, value); }
        }

        public bool IsRemove
        {
            get => (bool)GetValue(IsRemoveProperty); 
            set { SetValue(IsRemoveProperty, value); }
        }

        public bool IsButtonVisible
        {
            get => (bool)GetValue(IsButtonVisibleProperty); 
            set { SetValue(IsButtonVisibleProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(UserModel),
            typeof(MobileUserControl),
            null);

        public static readonly DependencyProperty IsRemoveProperty = DependencyProperty.Register(
            "ButtonContent",
            typeof(bool),
            typeof(MobileUserControl),
            null);

        public static readonly DependencyProperty IsButtonVisibleProperty = DependencyProperty.Register(
            "IsButtonVisible",
            typeof(bool),
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
