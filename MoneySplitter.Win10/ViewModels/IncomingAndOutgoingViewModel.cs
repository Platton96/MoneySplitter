using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.ObjectModel;
using MoneySplitter.Win10.Common;
using System.Threading.Tasks;
using System.Linq;
using MoneySplitter.Models.App;

namespace MoneySplitter.Win10.ViewModels
{
    public class IncomingAndOutgoingViewModel : Screen
    {
        #region Fields
        private ObservableCollection<CollaboratorModel> _debtors;
        private ObservableCollection<CollaboratorModel> _lendPersons;

        private bool _isLoading;

        private readonly INavigationManager _navigationManager;
        private readonly IFriendsManager _friendsManager;
        private readonly CollaboratorModelFactory _collabaratorModelFactory;
        private readonly ITransactionsManager _transactionsManager;
        private readonly ILocalizationService _localizationService;

        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;
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
        public IncomingAndOutgoingViewModel(
            CollaboratorModelFactory collaboratorModelFactory,
            INavigationManager navigationManager,
            ITransactionsManager transactionsManager,
            IFriendsManager friendsManager,
            ILocalizationService localizationService)
        {
            _collabaratorModelFactory = collaboratorModelFactory;
            _navigationManager = navigationManager;
            _transactionsManager = transactionsManager;
            _friendsManager = friendsManager;
            _localizationService = localizationService;
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            IsLoading = true;
            var executionResult = await _transactionsManager.GetUserTransactionsAsync();
            IsLoading = false;

            if (!executionResult.IsSuccess)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.DEFAULT_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.PROBLEM_SERVER_ERROR)
                };

                IsErrorVisible = true;
                return;
            }

            Debtors = new ObservableCollection<CollaboratorModel>(await _collabaratorModelFactory.GetDebtors());
            LendPersons = new ObservableCollection<CollaboratorModel>(await _collabaratorModelFactory.GetLendPersons());
        }

        public async Task MoveUserToInProgressAsync(int transactionId)
        {
            await _transactionsManager.MoveUserToInProgressAsync(transactionId);
        }

        public async Task MoveUserToFinishedAsync(int transactionId, int userId)
        {
            await _transactionsManager.MoveUserToFinishedAsync(transactionId, userId);
        }

        public async void NavigateToFriendDetails(int friendId)
        {
            var friend = (await _friendsManager.GetUserFriendsAsync()).Result.FirstOrDefault(fr => fr.Id == friendId);
            _navigationManager.NavigateToFriendDetails(friend);
        }

    }
}
