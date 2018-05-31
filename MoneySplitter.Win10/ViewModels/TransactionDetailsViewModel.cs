using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;

namespace MoneySplitter.Win10.ViewModels
{
	public class TransactionDetailsViewModel : Screen
	{
		private readonly IMembershipService _membershipService;

		private TransactionEventModel _data;
		private bool _isMyTransaction;

		public TransactionEventModel Parameter { get; set; }

		public TransactionEventModel Data
		{
			get => _data;
			set
			{
				_data = value;
				NotifyOfPropertyChange(nameof(Data));
			}
		}

		public bool IsMyTransaction
		{
			get => _isMyTransaction;
			set
			{
				_isMyTransaction = value;
				NotifyOfPropertyChange(nameof(IsMyTransaction));
			}
		}

		public TransactionDetailsViewModel(IMembershipService membershipService)
		{
			_membershipService = membershipService;
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			Data = Parameter;

			IsMyTransaction = Data.RootTransaction.Owner.Id == _membershipService.CurrentUser.Id;
		}
	}
}
