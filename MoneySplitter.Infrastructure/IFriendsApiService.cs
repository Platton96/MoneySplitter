using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsApiService
    {
        Task<bool> AddFriendAsync(string token, string email, int friendId);
        Task<IEnumerable<UserModel>> GetAllUserFriendsAsync(string token, string email);
        Task<bool> RemoveFriendAsync(string token, string email, int idFriend);
        Task<bool> RemoveFriendAsync(string token, string email, int friendId);
    }
}
