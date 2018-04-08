using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFriendsApiService
    {
        Task<bool> AddFriendAsync(string token, string email, int idFriend);
    }
}
