using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System.Collections.ObjectModel;
using System.Linq;
using MoneySplitter.Win10.Common;


namespace MoneySplitter.Win10.ViewModels
{
    public class IncomingAndOutcomingViewModel :Screen
    {
        #region Fields
        private ObservableCollection<CollabaratorModel> _debtors;
        private ObservableCollection<CollabaratorModel> _lendPersons;

        private bool _isNotTransactionsTextVisibility;

        private INavigationManager _navigationManager;
        private CollabaratorModelFactory _collabaratorModelFactory;
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

        public ObservableCollection<CollabaratorModel>LendPersons
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
        #endregion
        public IncomingAndOutcomingViewModel(CollabaratorModelFactory collabaratorModelFactory, INavigationManager navigationManager)
        {
            _collabaratorModelFactory = collabaratorModelFactory;
            _navigationManager = navigationManager;
        }
      


    }
}
