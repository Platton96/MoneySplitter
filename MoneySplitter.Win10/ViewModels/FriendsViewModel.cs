using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class FriendsViewModel : Screen
    {
        #region Fields
        private ObservableCollection<UserModel> _friends;

        private readonly IFriendsManager _friendsManager;
        private readonly INavigationManager _navigationManager;
        private readonly ILocalizationService _localizationService;

        private bool _isNotFriendsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;
        #endregion

        #region Properties
        public ObservableCollection<UserModel> Friends
        {
            get => _friends;
            set
            {
                _friends = value;
                NotifyOfPropertyChange(nameof(Friends));
            }
        }

        public bool IsNotFriendsTextVisibility
        {
            get => _isNotFriendsTextVisibility;
            set
            {
                _isNotFriendsTextVisibility = value;
                NotifyOfPropertyChange(nameof(IsNotFriendsTextVisibility));
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
        public FriendsViewModel(IFriendsManager friendsManager, INavigationManager navigationManager, ILocalizationService localizationService)
        {
            _friendsManager = friendsManager;
            _navigationManager = navigationManager;
            _localizationService = localizationService;
        }
        #endregion

        #region Methods
        public async Task RemoveFriendAsync(int friendId)
        {
            var friend = Friends.FirstOrDefault(x => x.Id == friendId);
            Friends.Remove(friend);

            var isSuccessResponce = await _friendsManager.RemoveFriendAsync(friendId);
        }

        public void NavigateToFriendDetails(UserModel friend)
        {
            _navigationManager.NavigateToFriendDetails(friend);
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            IsLoading = true;
            IsErrorVisible = false;
            IsNotFriendsTextVisibility = false;

            var executionResult = await _friendsManager.GetUserFriendsAsync();

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

            if (!executionResult.Result.Any())
            {
                IsNotFriendsTextVisibility = true;
                return;
            }

            Friends = new ObservableCollection<UserModel>(executionResult.Result);
        }
        #endregion
    }
}

