using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Services.Inerfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Services
{
    public class FriendshipService
    {
        public IMembershipService _membershipService;
        public IFriendsApiService _friendsApiService;

        public IMapper _mapper;

        public IEnumerable<UserModel> FriendsOfCurentUser { get; set; }

        public FriendshipService(IMembershipService membershipService, IFriendsApiService friendsApiService, IMapper mapper)
        {
            _membershipService = membershipService;
            _friendsApiService = friendsApiService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetFriendsOfCurrentUserAsunc()
        {
            var dataGetUser = _mapper.ConvertUserModelToDataGetUser(_membershipService.CurrentUser);

            var friendsOfCurentUser = await _friendsApiService.GetAllFriendsOfUserAsync(dataGetUser);

            FriendsOfCurentUser = friendsOfCurentUser;

            return friendsOfCurentUser;
        }
    }
}
