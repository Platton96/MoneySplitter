using MoneySplitter.Models;
using MoneySplitter.Win10.CustomControls.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MoneySplitter.Win10.CustomControls
{
	public sealed partial class TransactionStatusControl : UserControl
	{
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
					UserRole.MY_TRANSACTION,
					new UserRoleLabelModel
					{
						Content=Defines.UserRoleLabel.Content.USER_TRANSACTION,
						Color = DarkBlueBrush
					}
				}
			};

		}
	}
}
