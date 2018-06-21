using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Win10.CustomControls.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class TransactionStatusControl : UserControl
    {
        private ILocalizationService _localizationService = Dependecies.Dependecies.LocalizationService;

        public static readonly DependencyProperty RoleProperty = DependencyProperty.Register(
          "Role",
          typeof(UserRole),
          typeof(TransactionStatusControl),
          new PropertyMetadata(default(UserRole), new PropertyChangedCallback(OnRoleChanged)));

        public UserRole Role
        {
            get => (UserRole)GetValue(RoleProperty);
            set => SetValue(RoleProperty, value);
        }

        private IDictionary<UserRole, UserRoleLabelModel> _userRoleLabels;

        public TransactionStatusControl()
        {
            InitializeComponent();
            InitializeUserRoleLabels();
        }

        public static void OnRoleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            var control = (TransactionStatusControl)sender;
            control.UpdateUserRole();
        }

        public void UpdateUserRole()
        {
            UserRoleLabelBorder.Background = _userRoleLabels[Role].Color;
            UserRoleLabel.Text = _userRoleLabels[Role].Content;
        }

        private void InitializeUserRoleLabels()
        {
            _userRoleLabels = new Dictionary<UserRole, UserRoleLabelModel>()
            {
                {
                    UserRole.IN_BEGIN,
                    new UserRoleLabelModel
                    {
                        Content = _localizationService.GetString(Texts.USER_ROLE_LABEL_IN_BEGIN_TEXT),
                        Color = RedBrush
                    }
                },

                {
                    UserRole.IN_PROGRESS,
                    new UserRoleLabelModel
                    {
                        Content = _localizationService.GetString(Texts.USER_ROLE_LABEL_IN_PROGRESS_TEXT),
                        Color = YellowBrush
                    }
                },
                {
                    UserRole.FINISHED,
                    new UserRoleLabelModel
                    {
                        Content = _localizationService.GetString(Texts.USER_ROLE_LABEL_FINISHED_TEXT),
                        Color = GreenBrush
                    }
                },
                {
                    UserRole.MY_TRANSACTION,
                    new UserRoleLabelModel
                    {
                        Content = _localizationService.GetString(Texts.USER_ROLE_LABEL_USER_TRANSACTION_TEXT),
                        Color = DarkBlueBrush
                    }
                }
            };

        }
    }
}
