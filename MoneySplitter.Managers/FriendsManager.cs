using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Managers
{
    public class FriendsManager : IFriendsManager
    {
        private readonly IFriendsApiService _friendsApiService;
        private readonly IMembershipService _membershipService;

        public IEnumerable<UserModel> UserFriends { get; private set; }

        public FriendsManager(IFriendsApiService friendsApiService, IMembershipService membershipService)
        {
            _friendsApiService = friendsApiService;
            _membershipService = membershipService;
        }

        public async Task<bool> AddFriendAsync(int friendId)
        {
            return await _friendsApiService.AddFriendAsync(friendId);
        }

        public async Task<bool> LoadUserFriendsAsync()
        {
            var executionResult = await _friendsApiService.GetAllUserFriendsAsync();
            UserFriends = executionResult.Result;

            return executionResult.IsSuccess;
        }

        public async Task<ExecutionResult<IEnumerable<UserModel>>> GetUserFriendsAsync()
        {
            return await _friendsApiService.GetAllUserFriendsAsync();
        }

        public async Task<bool> RemoveFriendAsync(int friendId)
        {
            return await _friendsApiService.RemoveFriendAsync(friendId);
        }
    }
}
