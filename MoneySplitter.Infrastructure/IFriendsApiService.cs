using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsApiService
    {
        Task<bool> AddFriendAsync(string token, string email, int idFriend);
        Task<IEnumerable<UserModel>> GetAllFriendsOfUserAsync(string token, string emai);
        Task<bool> RemoveFriendAsync(string token, string email, int idFriend);
    }
}
