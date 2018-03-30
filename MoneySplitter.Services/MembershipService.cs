using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Services.Api;
using MoneySplitter.Infrastructure;

namespace MoneySplitter.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly SessionApiService _sessionApiServices;

        public UserModel CurrentUser { get; private set; }

        public MembershipService()
        {
            _sessionApiServices = new SessionApiService();
        }

        public async Task LoadUserData(string email, string password)
        {
            CurrentUser = await _sessionApiServices.SignInAsync(email, password);
        }
    }
}
