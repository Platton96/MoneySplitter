using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsManager
    {
        IEnumerable<UserModel> FriendsOfCurentUser { get; }

        Task<bool> AddFriendAsync(int idFriend);
        Task<bool> RemoveFriendAsync(int idFriend);

        Task LoadFriendsOfCurrentUserAsync();
    }
}
