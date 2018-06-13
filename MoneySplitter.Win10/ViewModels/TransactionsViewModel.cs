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
    public class TransactionsViewModel : Screen
    {
        #region Fields
        private ObservableCollection<TransactionEventModel> _transactions;

        public IEnumerable<SortModel> SortModels { get; private set; }

        private IDictionary<SortParameter, Func<TransactionEventModel, IComparable>> _getParameterFunctions =
            new Dictionary<SortParameter, Func<TransactionEventModel, IComparable>>()
            {
                {
                    SortParameter.CREATION_DATE,
                    x=>x.CreatingDate!=null?x.CreatingDate:DateTime.Now
                },

                {
                    SortParameter.TRANSACTION_NAME,
                    x=>x.Title
                },

                {
                    SortParameter.SINGLE_COST,
                    x=>x.SingleCost
                },

                {
                    SortParameter.TRANSACTION_DATE,
                    x=>x.Date
                },

                {
                    SortParameter.USER_ROLE,
                    x=>x.UserRole
                },

    };
        private readonly ITransactionsManager _transactionsManager;
        private readonly INavigationManager _navigationManager;
        private readonly TransactionEventModelFactory _transactionEventModelFactory;

        private SortModel _selectSortType;
        private bool _isNotTransactionsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;

        #endregion

        #region Properties
        public ObservableCollection<TransactionEventModel> Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                NotifyOfPropertyChange(nameof(Transactions));
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

        public SortModel SelectTypeSort
        {
            get => _selectSortType;
            set
            {
                if(value == _selectSortType)
                {
                    return;
                }

                _selectSortType = value;
                NotifyOfPropertyChange(nameof(SelectTypeSort));
            }
        }

        #endregion

        #region Constructor
        public TransactionsViewModel(
            ITransactionsManager transactionsManager,
            INavigationManager navigationManager,
            TransactionEventModelFactory transactionEventModelFactory)
        {
            _transactionsManager = transactionsManager;
            _navigationManager = navigationManager;
            _transactionEventModelFactory = transactionEventModelFactory;
            InializeSortModels();
            SelectTypeSort = SortModels.FirstOrDefault();
        }
        #endregion

        #region Methods
        protected override async void OnActivate()
        {
            base.OnActivate();


            IsLoading = true;
            IsErrorVisible = false;
            IsNotTransactionsTextVisibility = false;

            var isSuccessExecution = await _transactionsManager.LoadUserTransactionsAsync();

            IsLoading = false;
            if (!isSuccessExecution)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = Defines.ErrorDetails.DEFAULT_ERROR_TITLE,
                    ErrorDescription = Defines.ErrorDetails.PROBLEM_SERVER
                };

                IsErrorVisible = true;
                return;
            }
            if (_transactionsManager.UserTransactions.Count() == 0)
            {
                IsNotTransactionsTextVisibility = true;
                return;
            }

            Transactions = new ObservableCollection<TransactionEventModel>(_transactionEventModelFactory.GetTransactionEvents(_transactionsManager.UserTransactions));
        }

        public async Task MoveUserToInProgressAsync(int transactionId)
        {
            IsLoading = true;

            var isSuccessExecution = await _transactionsManager.MoveUserToInProgressAsync(transactionId) &&
                await _transactionsManager.LoadUserTransactionsAsync();

            IsLoading = false;
            if (!isSuccessExecution)
            {
                IsErrorVisible = true;
                return;
            }
            Transactions = new ObservableCollection<TransactionEventModel>(_transactionEventModelFactory.GetTransactionEvents(_transactionsManager.UserTransactions));

        }

        public void NavigateToAddTransaction()
        {
            _navigationManager.NavigateToAddTransactionViewModel();
        }
        
        public void SortTransactionEventModel()
        {
            SortTransactionEventModel(SelectTypeSort.SortParameter);
        }

        private void SortTransactionEventModel(SortParameter sortParameter)
        {
            if(Transactions==null)
            {
                return;
            }
            var getParameter = _getParameterFunctions[sortParameter];
            Transactions= new ObservableCollection <TransactionEventModel>( Transactions.OrderBy(x => getParameter(x)));
        }

        private void InializeSortModels()
        {
            SortModels = new[]
            {
                new SortModel
                {
                    SortParameter = SortParameter.CREATION_DATE,
                    Title = Defines.SortModel.Title.CREATING_DATE
                },
                new SortModel
                {
                    SortParameter = SortParameter.TRANSACTION_NAME,
                    Title = Defines.SortModel.Title.NAME_TRANSACTION
                },
                new SortModel
                {
                    SortParameter = SortParameter.SINGLE_COST,
                    Title = Defines.SortModel.Title.SINGLE_COST
                },
                new SortModel
                {
                    SortParameter = SortParameter.TRANSACTION_DATE,
                    Title = Defines.SortModel.Title.TRANSACTION_DATE
                },
                new SortModel
                {
                    SortParameter = SortParameter.USER_ROLE,
                    Title = Defines.SortModel.Title.USER_ROLE
                }

            };
        }

		public void NavigateToTransactionDetails(TransactionEventModel transaction)
		{
			_navigationManager.NavigateToTransactionDetailsViewModel(transaction);
		}
        #endregion
    }
}
