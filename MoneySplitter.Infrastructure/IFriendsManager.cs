using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsManager
    {
        IEnumerable<UserModel> UserFriends { get; }

        Task<bool> AddFriendAsync(int friendId);
        Task<bool> RemoveFriendAsync(int friendId);

        Task LoadCurrentFriendsUserAsync();
    }
}
