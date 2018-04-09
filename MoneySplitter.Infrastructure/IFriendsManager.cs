using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsManager
    {
        Task<bool> AddFriendAsync(int idFriend);
        Task LoadFriendsOfCurrentUserAsync();
        IEnumerable<UserModel> FriendsOfCurentUser { get; }
    }
}
