using MoneySplitter.Models;
using MoneySplitter.Win10.CustomControls.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class FriendTransactionControl : UserControl
    {
        public event EventHandler<FriendTransactionModel> OnGiveTransactionButtonClick;
        public event EventHandler<FriendTransactionModel> OnRemindTransactionButtonClick;
        public event EventHandler<FriendTransactionModel> OnApproveTransactionButtonClick;

        private IDictionary<UserRole, UserRoleLabelModel> _userRoleLabels;

        public FriendTransactionModel ViewModel
        {
            get { return (FriendTransactionModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }


        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(FriendTransactionModel),
            typeof(FriendTransactionControl),
            new PropertyMetadata(default(FriendTransactionModel ), new PropertyChangedCallback(OnValueChanged)));


        public FriendTransactionControl()
        {
            InitializeComponent();
            InitializeUserRoleLabels();
        }

        public static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            var control = (FriendTransactionControl)sender;
            control.UpdateArrowsStatus();
        }

        private void InitializeUserRoleLabels()
        {
            _userRoleLabels = new Dictionary<UserRole, UserRoleLabelModel>()
            {
                {
                    UserRole.IN_BEGIN,
                    new UserRoleLabelModel
                    {
                        Content=Defines.UserRoleLabel.Content.IN_BEGIN,
                        Color = RedBrush
                    }
                },

                {
                    UserRole.IN_PROGRESS,
                    new UserRoleLabelModel
                    {
                        Content=Defines.UserRoleLabel.Content.IN_PROGRESS,
                        Color = YellowBrush
                    }
                },
                {
                    UserRole.FINISHED,
                    new UserRoleLabelModel
                    {
                        Content=Defines.UserRoleLabel.Content.FINISHED,
                        Color = GreenBrush
                    }
                }
            };

        }

        public void UpdateArrowsStatus()
        {
         
        }

        private void OnGiveButtonClick(object sender, RoutedEventArgs e)
        {
            OnGiveTransactionButtonClick?.Invoke(this, ViewModel);
        }

        private void OnRemindButtonClick(object sender, RoutedEventArgs e)
        {
            OnRemindTransactionButtonClick?.Invoke(this, ViewModel);
        }

        private void OnApproveButtonClick(object sender, RoutedEventArgs e)
        {
            OnApproveTransactionButtonClick?.Invoke(this, ViewModel);
        }

    }
}
