using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class FriendDetailsViewModel : Screen
    {
        #region Fields

        private readonly ITransactionsManager _transactionsManager;

        private UserModel _friend;

        private bool _isNotTransactionsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;

        #endregion

        #region Properties
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
        public FriendDetailsViewModel(ITransactionsManager transactionsManager)
        {
            _transactionsManager = transactionsManager;
        }
        #endregion
        public UserModel Parameter { get; set; }
        protected override void OnActivate()
        {
            base.OnActivate();
            Friend = Parameter;
        }
    }
}
