using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class FriendsViewModel : Screen
    {
        private ObservableCollection<UserModel> _friends;

        private IFriendsManager _friendsManager;

        public ObservableCollection<UserModel> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                NotifyOfPropertyChange(nameof(Friends));
            }
        }

        public FriendsViewModel(IFriendsManager friendsManager)
        {
            _friendsManager = friendsManager;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            Friends = new ObservableCollection<UserModel>(_friendsManager.FriendsOfCurentUser);
        }

        public async Task RemoveFriendAsync(int idFriend)
        {
            var friend = Friends.Where(x => x.Id == idFriend).First();
            Friends.Remove(friend);

            var isSuccessResponce = await _friendsManager.RemoveFriendAsync(idFriend);

            if (isSuccessResponce)
            {
                await _friendsManager.LoadCurrentFriendsUserAsync();
            }
        }

    }
}

