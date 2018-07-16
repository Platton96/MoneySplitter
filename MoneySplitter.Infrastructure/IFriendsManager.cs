using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsManager
    {
        Task<bool> AddFriendAsync(int friendId);
        Task<bool> RemoveFriendAsync(int friendId);
        Task<ExecutionResult<IEnumerable<UserModel>>> GetUserFriendsAsync();
    }
}
