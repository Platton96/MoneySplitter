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



		public TransactionEventModel ViewModel
		{
			get { return (TransactionEventModel)GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}


		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel",
			typeof(TransactionEventModel),
			typeof(TransactionEventControl),
			new PropertyMetadata(default(TransactionEventModel)));

		public TransactionEventControl()
		{
			InitializeComponent();
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
