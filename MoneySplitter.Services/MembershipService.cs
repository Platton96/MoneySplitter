using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Models.Session;
using MoneySplitter.Services.API;
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

        public async Task LoadUserData(LoginModel loginModel)
        {
            CurrentUser = await _sessionApiServices.SignIn(loginModel);
        }
    }
}
