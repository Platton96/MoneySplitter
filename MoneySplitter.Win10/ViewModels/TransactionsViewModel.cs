﻿using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoneySplitter.Win10.ViewModels
{
    public class TransactionsViewModel : Screen
    {
        private ObservableCollection<TransactionModel> _transactions;

        private ITransactionsManager _transactionsManager;

        private bool _isNotTransactionsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;

        public ObservableCollection<TransactionModel> Transactions
        {
            get { return _transactions; }
            set
            {
                _transactions = value;
                NotifyOfPropertyChange(nameof(Transactions));
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

        public bool IsErrorVisible
        {
            get { return _isErrorVisible; }
            set
            {
                _isErrorVisible = value;
                NotifyOfPropertyChange(nameof(IsErrorVisible));
            }
        }

        public ErrorDetailsModel ErrorDetailsModel
        {
            get { return _errorDetailsModel; }
            set
            {
                _errorDetailsModel = value;
                NotifyOfPropertyChange(nameof(ErrorDetailsModel));
            }
        }
        
        public TransactionsViewModel(ITransactionsManager transactionsManager)
        {
            _transactionsManager = transactionsManager;
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            IsLoading = true;
            IsErrorVisible = false;
            IsNotTransactionsTextVisibility = false;

            var isSuccessExecution = await _transactionsManager.LoadUserTransactions();

            IsLoading = false;
            if (!isSuccessExecution)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = Defines.ErrorDetails.Login.ERROR_TITLE,
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

            Transactions = new ObservableCollection<TransactionModel>(_transactionsManager.UserTransactions);
        }
    }
}