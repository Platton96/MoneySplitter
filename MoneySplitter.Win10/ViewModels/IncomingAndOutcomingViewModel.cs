using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.ObjectModel;
using MoneySplitter.Win10.Common;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class IncomingAndOutcomingViewModel : Screen
    {
        #region Fields
        private ObservableCollection<CollaboratorModel> _debtors;
        private ObservableCollection<CollaboratorModel> _lendPersons;

        private bool _isNotTransactionsTextVisibility;
        private bool _isLoading;

        private INavigationManager _navigationManager;
        private CollaboratorModelFactory _collabaratorModelFactory;
        private ITransactionsManager _transactionsManager;
        #endregion

        #region Properties
        public ObservableCollection<CollaboratorModel> Debtors
        {
            get { return _debtors; }
            set
            {
                _debtors = value;
                NotifyOfPropertyChange(nameof(Debtors));
            }
        }

        public ObservableCollection<CollaboratorModel> LendPersons
        {
            get { return _lendPersons; }
            set
            {
                _lendPersons = value;
                NotifyOfPropertyChange(nameof(LendPersons));
            }
        }

        public bool IsNotTransactionsTextVisibility
        {
            get { return _isNotTransactionsTextVisibility; }
            set
            {
                _isNotTransactionsTextVisibility = value;
                NotifyOfPropertyChange(nameof(IsNotTransactionsTextVisibility));
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }
        #endregion
        public IncomingAndOutcomingViewModel(CollaboratorModelFactory collaboratorModelFactory, INavigationManager navigationManager, ITransactionsManager transactionsManager)
        {
            _collabaratorModelFactory = collaboratorModelFactory;
            _navigationManager = navigationManager;
            _transactionsManager = transactionsManager;

        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            if (_transactionsManager.UserTransactions == null)
            {
                IsLoading = true;
                await _transactionsManager.LoadUserTransactionsAsync();
                IsLoading = false;
            }

            Debtors = new ObservableCollection<CollaboratorModel>(_collabaratorModelFactory.GetDebtors());
            LendPersons = new ObservableCollection<CollaboratorModel>(_collabaratorModelFactory.GetLendPersons());

        }

        public async Task MoveUserToInProgress(int transactionId)
        {
            await _transactionsManager.MoveUserToInProgress(transactionId);
        }

        public async Task MoveUserToFinished(int transactionId, int userId)
        {
            await _transactionsManager.MoveUserToFinished(transactionId, userId);
        }

    }
}
