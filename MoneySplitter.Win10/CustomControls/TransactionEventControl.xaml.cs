using MoneySplitter.Models;
using MoneySplitter.Win10.CustomControls.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class TransactionEventControl : UserControl
    {
        public event EventHandler<TransactionEventModel> OnGiveTransactionButtonClick;
        public event EventHandler<TransactionEventModel> OnRemindTransactionButtonClick;
        public event EventHandler<TransactionEventModel> OnApproveTransactionButtonClick;

        private IDictionary<UserRole, UserRoleLabelModel> _userRoleLabels;

        public TransactionEventModel ViewModel
        {
            get { return (TransactionEventModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }


        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(TransactionEventModel),
            typeof(TransactionEventControl),
            new PropertyMetadata(default(TransactionEventModel), new PropertyChangedCallback(OnValueChanged)));


        public TransactionEventControl()
        {
            InitializeComponent();
            InitializeUserRoleLabels();
        }

        public static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            var control = (TransactionEventControl)sender;
            control.UpdateUserRole();
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
                },
                {
                    UserRole.USER_TRANSACTION,
                    new UserRoleLabelModel
                    {
                        Content=Defines.UserRoleLabel.Content.USER_TRANSACTION,
                        Color = DarkBlueBrush
                    }
                }
            };

        }

        public void UpdateUserRole()
        {
            UserRoleLabelBorder.Background = _userRoleLabels[ViewModel.UserRole].Color;
            UserRoleLabel.Text = _userRoleLabels[ViewModel.UserRole].Content;
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
