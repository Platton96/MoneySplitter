using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Models.Session;

namespace MoneySplitter.Infrastructure
{
    public interface ISessionApiService
    {
        Task<UserModel> SignInAsync(string email, string password);
        Task<UserModel> RegistrAsync(RegisterModel registrModel);
    }
}
