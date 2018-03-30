using System.Threading.Tasks;
using MoneySplitter.Models;

namespace MoneySplitter.Infrastructure
{
    public interface ISessionApiService
    {
        Task<UserModel> SignInAsync(string email, string password);
    }
}
