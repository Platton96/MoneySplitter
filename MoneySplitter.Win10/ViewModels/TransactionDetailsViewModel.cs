using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
	public class TransactionDetailsViewModel : Screen
	{
		private readonly IMembershipService _membershipService;
        private readonly ITransactionsManager _transactionsManager;
        private readonly ILocalizationService _localizationService;

        private TransactionEventModel _data;
		private bool _isOngoingDateAvailable;
		private bool _isMyTransaction;

		private int _collaboratorsCount;
		private int _inProgressCount;
		private int _finishedCount;
        private ErrorDetailsModel _errorDetailsModel;
        private bool _isLoading;
        private bool _isErrorVisible;

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
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                NotifyOfPropertyChange(nameof(IsErrorVisible));
            }
        }

        public ErrorDetailsModel ErrorDetailsModel
        {
            get => _errorDetailsModel;
            set
            {
                _errorDetailsModel = value;
                NotifyOfPropertyChange(nameof(ErrorDetailsModel));
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

		public TransactionDetailsViewModel(
            IMembershipService membershipService, 
            ITransactionsManager transactionsManager,
            ILocalizationService localizationService)
		{
			_membershipService = membershipService;
            _transactionsManager = transactionsManager;
            _localizationService = localizationService;
		}

        public async Task MoveUserToInProgressAsync()
        {
            IsLoading = true;

            var isSuccessExecution = await _transactionsManager.MoveUserToInProgressAsync(Data.TransactionId);
            IsLoading = false;

            if (!isSuccessExecution)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.DEFAULT_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.PROBLEM_SERVER_ERROR)
                };

                IsErrorVisible = true;
                return;
            }
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
