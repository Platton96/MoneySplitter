using MoneySplitter.Models;
using MoneySplitter.Models.Session;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IMembershipService
    {
        Task SingInAndLoadUserDataAsync(string email, string password);
        Task ReistrAndLoadUserDataAsync(RegistrModel registrModel);
        UserModel CurrentUser { get;  }
    }
}
