using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.ObjectModel;
using MoneySplitter.Win10.Common;


namespace MoneySplitter.Win10.ViewModels
{
    public class IncomingAndOutcomingViewModel :Screen
    {
        #region Fields
        private ObservableCollection<CollabaratorModel> _debtors;
        private ObservableCollection<CollabaratorModel> _lendPersons;

        private bool _isNotTransactionsTextVisibility;
        private bool _isLoading;

        private INavigationManager _navigationManager;
        private CollabaratorModelFactory _collabaratorModelFactory;
        private ITransactionsManager _transactionsManager;
        #endregion

        #region Properties
        public ObservableCollection<CollabaratorModel> Debtors
        {
            get { return _debtors; }
            set
            {
                _debtors = value;
                NotifyOfPropertyChange(nameof(Debtors));
            }
        }

        public ObservableCollection<CollabaratorModel> LendPersons
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
        public IncomingAndOutcomingViewModel(CollabaratorModelFactory collabaratorModelFactory, INavigationManager navigationManager, ITransactionsManager transactionsManager)
        {
            _collabaratorModelFactory = collabaratorModelFactory;
            _navigationManager = navigationManager;
            _transactionsManager = transactionsManager;
            
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            if (_transactionsManager.UserTransactions == null)
            {
                IsLoading = true;
               await  _transactionsManager.LoadUserTransactionsAsync();
                IsLoading = false;
            }

            Debtors = new ObservableCollection<CollabaratorModel> (_collabaratorModelFactory.GetDebtors());
            LendPersons = new ObservableCollection<CollabaratorModel>(_collabaratorModelFactory.GetLendPersons());

        }

    }
}
