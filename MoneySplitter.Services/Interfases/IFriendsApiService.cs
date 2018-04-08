using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Services.Inerfaces
{
    public interface IFriendsApiService
    {
        Task<bool> AddFriendAsync(string token, string email, int idFriend);
        Task<IEnumerable<UserModel>> GetAllFriendsOfUserAsync(DataGetUser dataGetUser);
    }
}
