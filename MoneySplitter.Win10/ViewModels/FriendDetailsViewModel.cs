using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using MoneySplitter.Win10.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class FriendDetailsViewModel : Screen
    {
        #region Fields

        private readonly ITransactionsManager _transactionsManager;
        private readonly FriendTransactionModelFactory _friendTransactionModelFactory;
        private readonly TransactioEventModelFactory _transactioEventModelFactory;

        private UserModel _friend;

        private IEnumerable<TransactionModel> _friendTransactions;

        private ObservableCollection<FriendTransactionModel> _debts;
        private ObservableCollection<FriendTransactionModel> _lends;
        private ObservableCollection<TransactionEventModel> _transactionEvents;

        private bool _isNotTransactionsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;

        #endregion

        #region Properties

        public ObservableCollection<FriendTransactionModel> Debts
        {
            get => _debts;
            set
            {
                _debts = value;
                NotifyOfPropertyChange(nameof(Debts));
            }
        }

        public ObservableCollection<FriendTransactionModel> Lends
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
        public FriendDetailsViewModel(ITransactionsManager transactionsManager, 
            FriendTransactionModelFactory friendTransactionModelFactory,
            TransactioEventModelFactory transactioEventModelFactory)
            
        {
            _transactionsManager = transactionsManager;
            _friendTransactionModelFactory = friendTransactionModelFactory;
            _transactioEventModelFactory = transactioEventModelFactory;
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
                    ErrorTitle = Defines.ErrorDetails.Login.ERROR_TITLE,
                    ErrorDescription = Defines.ErrorDetails.PROBLEM_SERVER
                };

                IsErrorVisible = true;
                return;
            }

            _friendTransactions = executionResult.Result;
            Debts = new ObservableCollection<FriendTransactionModel>(_friendTransactionModelFactory.GetFriendDebts(_friendTransactions, Friend.Id));
            Lends = new ObservableCollection<FriendTransactionModel>(_friendTransactionModelFactory.GetFriendLends(_friendTransactions, Friend.Id));
            TransactionEvents = new ObservableCollection<TransactionEventModel>(_transactioEventModelFactory.GetTransactionEvents(_friendTransactions));
        }
    }
}
