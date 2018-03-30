using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Services.Api;
namespace MoneySplitter.Services
{
    public class MembershipService
    {
        private readonly SessionApiService _sessionApiServices;

        public UserModel CurrentUser { get; private set; }

        public MembershipService()
        {
            _sessionApiServices = new SessionApiService();
        }

        public async Task LoadUserData(string email, string password)
        {
            CurrentUser = await _sessionApiServices.SignIn(email, password);
        }
    }
}
