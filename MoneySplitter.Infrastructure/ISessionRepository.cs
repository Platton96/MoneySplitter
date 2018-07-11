using MoneySplitter.Models;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface ISessionRepository
    {
        Task<UserModel> GetUserAsync();
        Task ClearUssersTableAsync();
        Task AddUserAsync(UserModel userModel);
    }
}
