using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IMembershipService
    {
        Task LoadUserData(string email, string password);
    }
}
