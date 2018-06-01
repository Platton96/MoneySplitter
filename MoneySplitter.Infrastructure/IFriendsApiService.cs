using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsApiService
    {
        Task<bool> AddFriendAsync( int friendId);
        Task<ExecutionResult<IEnumerable<UserModel>>> GetAllUserFriendsAsync();
        Task<bool> RemoveFriendAsync(int friendId);
    }
}
