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

            var dataAddFriend = new DataAddFriend
            {
                Token = token,
                Email = email,
                FriendId = friendId
            };
 
            return await _queryApiService.PostAsync(dataAddFriend, apiUrlAddFriend);
        }

        public async Task<bool> RemoveFriendAsync(string token, string email, int friendId)
        {
            var apiUrlRemoveFriend = _apiUrlBuilder.RemoveFriend();

            var dataRemoveFriend = new DataRemoveFriend
            {
                Token = token,
                Email = email,
                FriendId = friendId
            };

            return await _queryApiService.PostAsync(dataRemoveFriend, apiUrlRemoveFriend);
        }

        public async Task<IEnumerable<UserModel>> GetAllFriendsOfUserAsync(string token, string email )
        {
            var apiUrlGetAllFriends = _apiUrlBuilder.GetAllFriends();

            var dataGetUser = new DataGetUser
            {
                Token = token,
                Email = email
            };

            var friendsUser = await _queryApiService.PostAsync<IEnumerable<DataUser>, DataGetUser>(dataGetUser, apiUrlGetAllFriends);

            return friendsUser.Select(x => _mapper.ConvertDataUserToUserModel(x)).ToList();
        }
    }
}
