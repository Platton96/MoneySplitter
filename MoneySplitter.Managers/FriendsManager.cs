﻿using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Services.Inerfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Managers
{
    public class FriendsManager : IFriendsManager
    {
        private IFriendsApiService _friendsApiService;
        private IMembershipService _membershipService;

        public IMapper _mapper;

        public IEnumerable<UserModel> UserFriends { get; private set; }

        public FriendsManager(IFriendsApiService friendsApiService, IMembershipService membershipService, IMapper mapper)
        {
            _friendsApiService = friendsApiService;
            _membershipService = membershipService;
            _mapper = mapper;
        }

        public async Task<bool> AddFriendAsync(int idFriend)
        {
            return await _friendsApiService.AddFriendAsync(_membershipService.CurrentUser.Token, _membershipService.CurrentUser.Email, idFriend);
        }

        public async Task LoadCurrentFriendsUserAsync()
        {
            UserFriends = await _friendsApiService.GetAllUserFriendsAsync(_membershipService.CurrentUser.Token, _membershipService.CurrentUser.Email);
        }

        public async Task<bool> RemoveFriendAsync(int idFriend)
        {
            return await _friendsApiService.RemoveFriendAsync(_membershipService.CurrentUser.Token, _membershipService.CurrentUser.Email, idFriend);
        }
    }
}
