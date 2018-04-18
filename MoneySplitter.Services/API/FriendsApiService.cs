using MoneySplitter.Infrastructure;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using System.Linq;
using System.Threading.Tasks;
using MoneySplitter.Models;
using System.Collections.Generic;

namespace MoneySplitter.Services.Api
{
    public class FriendsApiService : IFriendsApiService
    {
        private readonly IApiUrlBuilder _apiUrlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _mapper;

        public FriendsApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper)
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
        }

        public async Task<bool> AddFriendAsync(string token, string email, int friendId)
        {
            var apiUrlAddFriend = _apiUrlBuilder.AddFriend();

            var addFriendData = new AddFriendData
            {
                Token = token,
                Email = email,
                FriendId = friendId
            };
 
            return await _queryApiService.PostAsync(addFriendData, apiUrlAddFriend);
        }

        public async Task<bool> RemoveFriendAsync(string token, string email, int friendId)
        {
            var apiUrlRemoveFriend = _apiUrlBuilder.RemoveFriend();

            var removeFriendData = new RemoveFriendData
            {
                Token = token,
                Email = email,
                FriendId = friendId
            };

            return await _queryApiService.PostAsync(removeFriendData, apiUrlRemoveFriend);
        }

        public async Task<IEnumerable<UserModel>> GetAllUserFriendsAsync(string token, string email )
        {
            var apiUrlGetAllFriends = _apiUrlBuilder.GetAllFriends();

            var getUserData = new GetUserData
            {
                Token = token,
                Email = email
            };

            var userFriends = await _queryApiService.PostAsync<IEnumerable<UserData>, GetUserData>(getUserData, apiUrlGetAllFriends);

            return userFriends.Select(x => _mapper.ConvertDataUserToUserModel(x)).ToList();
        }
    }
}
