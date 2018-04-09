using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.Generic;

namespace MoneySplitter.Win10.ViewModels
{
    public class FriendsViewModel : Screen
    {
        private IEnumerable<UserModel> _friends;

        private IFriendsManager _friendsManager;

        public IEnumerable<UserModel> Friends
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
            Friends = _friendsManager.FriendsOfCurentUser;
        }

    }
}
