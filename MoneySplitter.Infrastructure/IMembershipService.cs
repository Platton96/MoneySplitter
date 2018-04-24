using MoneySplitter.Models;
using MoneySplitter.Models.Session;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IMembershipService
    {
        Task<bool> SingInAndLoadUserDataAsync(string email, string password);
        Task ReisterAndLoadUserDataAsync(RegisterModel registerModel);
        UserModel CurrentUser { get; }
    }
}
