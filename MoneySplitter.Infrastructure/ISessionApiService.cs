using System.Threading.Tasks;
using MoneySplitter.Models;

namespace MoneySplitter.Infrastructure
{
    public interface ISessionApiService<T> where T: class
    {
        Task<T> SignInAsync(string email, string password);
    }
}
