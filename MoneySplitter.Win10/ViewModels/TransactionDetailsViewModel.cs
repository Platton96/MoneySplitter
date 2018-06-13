using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Linq;

namespace MoneySplitter.Win10.ViewModels
{
	public class TransactionDetailsViewModel : Screen
	{
		private readonly IMembershipService _membershipService;

		private TransactionEventModel _data;
		private bool _isOngoingDateAvailable;
		private bool _isMyTransaction;

		private int _collaboratorsCount;
		private int _inProgressCount;
		private int _finishedCount;

		public int CollaboratorsCount
		{
			get => _collaboratorsCount;
			set
			{
				_collaboratorsCount = value;
				NotifyOfPropertyChange(nameof(CollaboratorsCount));
			}
		}

		public int InProgressCount
		{
			get => _inProgressCount;
			set
			{
				_inProgressCount = value;
				NotifyOfPropertyChange(nameof(InProgressCount));
			}
		}

		public int FinishedCount
		{
			get => _finishedCount;
			set
			{
				_finishedCount = value;
				NotifyOfPropertyChange(nameof(FinishedCount));
			}
		}

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

		public bool IsOngoingDateAvailable
		{
			get => _isOngoingDateAvailable;
			set
			{
				_isOngoingDateAvailable = value;
				NotifyOfPropertyChange(nameof(IsOngoingDateAvailable));
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
			IsOngoingDateAvailable = Data.RootTransaction.OngoingDate != null;
			CollaboratorsCount = Data.RootTransaction.Collaborators.Count();
			InProgressCount = Data.RootTransaction.InProgressIds.Count();
			FinishedCount = Data.RootTransaction.FinishedIds.Count();
		}
	}
}
