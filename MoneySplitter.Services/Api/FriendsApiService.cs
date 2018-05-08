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

        public async Task<bool> AddFriendAsync(int friendId)
        {
            var addFriendUrl = _apiUrlBuilder.AddFriend(friendId);

            return await _queryApiService.PostAsync(addFriendUrl);
        }

        public async Task<bool> RemoveFriendAsync(int friendId)
        {
            var removeFriendUrl = _apiUrlBuilder.RemoveFriend(friendId);

            return await _queryApiService.PostAsync(removeFriendUrl);
        }

        public async Task<ExecutionResult<IEnumerable<UserModel>>> GetAllUserFriendsAsync()
        {
            var result = new ExecutionResult<IEnumerable<UserModel>>
            {
                IsSuccess = false
            };

            var allFriendsUrl = _apiUrlBuilder.AllFriends();

            IEnumerable<UserData> userFriendsData = null;

            await _executor.ExecuteWithRetryAsync(async () =>
            {
                userFriendsData= await _queryApiService.GetAsync<IEnumerable<UserData>>(allFriendsUrl);
            });

            if (userFriendsData == null)
            {
                return result;
            }

            result.Result =
                userFriendsData.Select(x => _mapper.ConvertUserDataToUserModel(x)).ToList();

            result.IsSuccess = true;

            return result;
        }
    }
}
