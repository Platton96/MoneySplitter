using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using MoneySplitter.Win10.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class FriendDetailsViewModel : Screen
    {
        #region Fields

        private readonly ITransactionsManager _transactionsManager;
        private readonly TransactionEventModelFactory _transactionEventModelFactory;
        private readonly ILocalizationService _localizationService;
        private readonly INavigationManager _navigationManager;

        private UserModel _friend;

        private IEnumerable<TransactionModel> _friendTransactions;

        private ObservableCollection<TransactionEventModel> _debts;
        private ObservableCollection<TransactionEventModel> _lends;
        private ObservableCollection<TransactionEventModel> _transactionEvents;

        private bool _isNotTransactionsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        public double _debt;
        public bool _isDebt;
        private ErrorDetailsModel _errorDetailsModel;

        #endregion

        #region Properties

        public ObservableCollection<TransactionEventModel> Debts
        {
            get => _debts;
            set
            {
                _debts = value;
                NotifyOfPropertyChange(nameof(Debts));
            }
        }

        public ObservableCollection<TransactionEventModel> Lends
        {
            get => _lends;
            set
            {
                _lends = value;
                NotifyOfPropertyChange(nameof(Lends));
            }
        }

        public ObservableCollection<TransactionEventModel> TransactionEvents
        {
            get => _transactionEvents;
            set
            {
                _transactionEvents = value;
                NotifyOfPropertyChange(nameof(TransactionEvents));
            }
        }

        public UserModel Friend
        {
            get => _friend;
            set
            {
                _friend = value;
                NotifyOfPropertyChange(nameof(Friend));
            }
        }

        public bool IsNotTransactionsTextVisibility
        {
            get => _isNotTransactionsTextVisibility;
            set
            {
                _isNotTransactionsTextVisibility = value;
                NotifyOfPropertyChange(nameof(IsNotTransactionsTextVisibility));
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
        public bool IsDebt
        {
            get => _isDebt;
            set
            {
                _isDebt = value;
                NotifyOfPropertyChange(nameof(IsDebt));
            }
        }

        public double Debt
        {
            get => Math.Abs(_debt);
            set
            {
                _debt = value;
                NotifyOfPropertyChange(nameof(Debt));
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
        #endregion

        #region Constructor
        public FriendDetailsViewModel(
            ITransactionsManager transactionsManager,
            TransactionEventModelFactory transactionEventModelFactory,
            ILocalizationService localizationService,
            INavigationManager navigationManager)

        {
            _transactionsManager = transactionsManager;
            _transactionEventModelFactory = transactionEventModelFactory;
            _localizationService = localizationService;
            _navigationManager = navigationManager;
        }
        #endregion
        public UserModel Parameter { get; set; }

        protected override async void OnActivate()
        {
            base.OnActivate();
            Friend = Parameter;

            IsLoading = true;
            var executionResult = await _transactionsManager.GetFriendTransactionsAsync(Friend.Id);
            IsLoading = false;

            if (!executionResult.IsSuccess)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.REGISTER_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.REGISTER_ERROR_PASSWORD)
                };

                IsErrorVisible = true;
                return;
            }

            _friendTransactions = executionResult.Result;
            Debts = new ObservableCollection<TransactionEventModel>(_transactionEventModelFactory.GetFriendDebts(_friendTransactions, Friend.Id));
            Lends = new ObservableCollection<TransactionEventModel>(_transactionEventModelFactory.GetFriendLends(_friendTransactions, Friend.Id));
            Debt = Debts.Where(tr => tr.FriendRole == UserRole.IN_BEGIN || tr.FriendRole == UserRole.IN_PROGRESS).Sum(x => x.SingleCost) - Lends.Where(tr => tr.FriendRole == UserRole.IN_BEGIN || tr.FriendRole == UserRole.IN_PROGRESS).Sum(x => x.SingleCost);
            IsDebt = _debt > 0 ? true : false;
            TransactionEvents = new ObservableCollection<TransactionEventModel>(_transactionEventModelFactory.GetCommonTransationsByFriend(_friendTransactions, Friend.Id));
        }

        public async Task MoveUserToInProgressAsync(int transactionId)
        {
            IsLoading = true;
            var isSuccessExecution = await _transactionsManager.MoveUserToInProgressAsync(transactionId);
            var executionResult = await _transactionsManager.GetFriendTransactionsAsync(Friend.Id);
            IsLoading = false;
            if (!isSuccessExecution || !executionResult.IsSuccess)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.DEFAULT_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.PROBLEM_SERVER_ERROR)
                };

                IsErrorVisible = true;
                return;
            }
            OnActivate();
        }

        public async Task MoveUserToInFinishedAsync(int transactionId)
        {
            IsLoading = true;
            var isSuccessExecution = await _transactionsManager.MoveUserToFinishedAsync(transactionId, Friend.Id);
            var executionResult = await _transactionsManager.GetFriendTransactionsAsync(Friend.Id);
            IsLoading = false;

            if (!isSuccessExecution || !executionResult.IsSuccess)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.DEFAULT_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.PROBLEM_SERVER_ERROR)
                };

                IsErrorVisible = true;
                return;
            }
            OnActivate();
        }

        public async Task CloseAllTransactionAsync()
        {
            IsLoading = true;
            var isSuccessExecution = await _transactionsManager.ApproveAllAsync(Friend.Id);
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
            OnActivate();

        }

        public void NavigateToTransactionDetails(TransactionEventModel transaction)
        {
            _navigationManager.NavigateToTransactionDetailsViewModel(transaction);
        }
    }
}
