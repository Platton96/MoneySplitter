using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Win10.Common;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class SearchUsersViewModel : Screen
    {
        private IFriendsManager _friendsManager;

        public SearchEngine SearchEngine { get; set; }
        
        public SearchUsersViewModel(SearchEngine searchEngine, IFriendsManager friendsManager)
        {
            SearchEngine = searchEngine;
            _friendsManager = friendsManager;
        }

        public async Task AddFriendAsync(int friendId)
        {
            var isSuccessResponce = await _friendsManager.AddFriendAsync(friendId);

            if (isSuccessResponce)
            {
                await _friendsManager.LoadUserFriendsAsync();
            }
        }

        public void ChangedQuery(string query)
        {
            SearchEngine.ChangedQeury(query);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            SearchEngine.Activate();
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            SearchEngine.Deactivate();
        }

    }
}
