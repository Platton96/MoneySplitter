using MoneySplitter.Infrastructure;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using System.Linq;
using System.Threading.Tasks;
using MoneySplitter.Models;
using System.Collections.Generic;

namespace MoneySplitter.Services.API
{
    public class FriendsApiService : IFriendsApiService
    {
        private readonly IApiUrlBuilder _urlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _maper;

        public FriendsApiService(IApiUrlBuilder urlBuilder, IQueryApiService queryApiService, IMapper mapper)
        {
            _urlBuilder = urlBuilder;
            _queryApiService = queryApiService;
            _maper = mapper;
        }

        public async Task<bool> AddFriendAsync(string token, string email, int idFriend)
        {
            var uriAdditionFriend = _urlBuilder.AdditionFriend();

            var dataAddFriend = new DataAddFriend
            {
                Token = token,
                Email = email,
                IdFriend = idFriend
            };

            var isSuccessResponce = await _queryApiService.PostAsync(dataAddFriend, uriAdditionFriend);

            return isSuccessResponce;
        }

        public async Task<IEnumerable<UserModel>> GetAllFriendsOfUserAsync(DataGetUser dataGetUser )
        {
            var uriGetAllFriends = _urlBuilder.GetAllFriends();

            var friendsUser = await _queryApiService.PostAsync<IEnumerable<DataUser>, DataGetUser>(dataGetUser, uriGetAllFriends);

            return friendsUser.Select(x => _maper.ConvertDataUserToUserModel(x));
        }
    }
}
