using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Win10.Common;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class FoundUsersViewModel : Screen
    {
        private IFriendsManager _friendsManager;
        public SearchEngine SearchEngine { get; set; }
        
        public FoundUsersViewModel(SearchEngine searchEngine, IFriendsManager friendsManager)
        {
            SearchEngine = searchEngine;
            _friendsManager = friendsManager;
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

        public async Task AddFriendAsync(int idFriend)
        {
            var isSuccessResponce =await _friendsManager.AddFriendAsync(idFriend);

            if(isSuccessResponce)
            {
                await _friendsManager.LoadCurrentFriendsUserAsync();
            }
        }
    }
}
