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
        private ObservableCollection<UserModel> _friends;

        private IFriendsManager _friendsManager;

        private bool _isNotFriendsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;

        public ObservableCollection<UserModel> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                NotifyOfPropertyChange(nameof(Friends));
            }
        }

        public bool IsNotFriendsTextVisibility
        {
            get { return _isNotFriendsTextVisibility; }
            set
            {
                _isNotFriendsTextVisibility = value;
                NotifyOfPropertyChange(nameof(IsNotFriendsTextVisibility));
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

        public FriendsViewModel(IFriendsManager friendsManager)
        {
            _friendsManager = friendsManager;
        }

        public async Task RemoveFriendAsync(int friendId)
        {
            var friend = Friends.Where(x => x.Id == friendId).First();
            Friends.Remove(friend);

            var isSuccessResponce = await _friendsManager.RemoveFriendAsync(friendId);

            if (isSuccessResponce)
            {
                await _friendsManager.LoadUserFriendsAsync();
            }
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            IsLoading = true;
            IsErrorVisible = false;
            IsNotFriendsTextVisibility = false;

            var isSuccessExecution = await _friendsManager.LoadUserFriendsAsync();

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
            if (_friendsManager.UserFriends.Count()==0)
            {
                IsNotFriendsTextVisibility = true;
                return;
            }

            Friends = new ObservableCollection<UserModel>(_friendsManager.UserFriends);
        }
    }
}

