using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.ObjectModel;
using MoneySplitter.Win10.Common;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class IncomingAndOutgoingViewModel : Screen
    {
        #region Fields
        private ObservableCollection<CollaboratorModel> _debtors;
        private ObservableCollection<CollaboratorModel> _lendPersons;

        private bool _isLoading;

        private readonly INavigationManager _navigationManager;
        private readonly CollaboratorModelFactory _collabaratorModelFactory;
        private readonly ITransactionsManager _transactionsManager;
        #endregion

        #region Properties
        public ObservableCollection<CollaboratorModel> Debtors
        {
            get => _debtors; 
            set
            {
                _debtors = value;
                NotifyOfPropertyChange(nameof(Debtors));
            }
        }

        public ObservableCollection<CollaboratorModel> LendPersons
        {
            get => _lendPersons; 
            set
            {
                _lendPersons = value;
                NotifyOfPropertyChange(nameof(LendPersons));
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
        #endregion
        public IncomingAndOutgoingViewModel(
            CollaboratorModelFactory collaboratorModelFactory, 
            INavigationManager navigationManager,
            ITransactionsManager transactionsManager)
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

        public async Task MoveUserToInProgressAsync(int transactionId)
        {
            await _transactionsManager.MoveUserToInProgressAsync(transactionId);
        }

        public async Task MoveUserToFinishedAsync(int transactionId, int userId)
        {
            await _transactionsManager.MoveUserToFinishedAsync(transactionId, userId);
        }

    }
}
