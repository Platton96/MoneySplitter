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
        private readonly IExecutor _executor;

        public FriendsApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper, IExecutor executor)
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
            _executor = executor;
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

        public async Task<ExecutionResult<IEnumerable<UserModel>>> GetAllUserFriendsAsync(string token, string email )
        {
            var result = new ExecutionResult<IEnumerable<UserModel>>
            {
                IsSuccess = false
            };

            var apiUrlGetAllFriends = _apiUrlBuilder.GetAllFriends();

            var getUserData = new GetUserData
            {
                Token = token,
                Email = email
            };

            IEnumerable<UserData> userFriendsData = null;

            await _executor.ExecuteWithRetryAsync(async () =>
            {
                userFriendsData= await _queryApiService.PostAsync<IEnumerable<UserData>, GetUserData>(getUserData, apiUrlGetAllFriends);
            });

            if (userFriendsData == null)
            {
                return result;
            }

            result.Result = userFriendsData.Select(x => _mapper.ConvertUserDataToUserModel(x)).ToList();
            result.IsSuccess = true;
            return result;
        }
    }
}
