using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Models.Session;

namespace MoneySplitter.Infrastructure
{
    public interface ISessionApiService
    {
        Task<ExecutionResult<UserModel>> SignInAsync(string email, string password);
        Task<ExecutionResult<UserModel>> RegisterAsync(RegisterModel registerModel);
    }
}
