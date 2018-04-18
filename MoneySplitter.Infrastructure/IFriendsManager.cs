using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsManager
    {
        IEnumerable<UserModel> FriendsOfCurentUser { get; }

        Task<bool> AddFriendAsync(int friendId);
        Task<bool> RemoveFriendAsync(int friendId);

        Task LoadUserFriendsAsync();
    }
}
