using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Services.Api;
using MoneySplitter.Infrastructure;
using MoneySplitter.Services.DataModels;

namespace MoneySplitter.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly ISessionApiService _sessionApiServices;

        public UserModel CurrentUser { get; private set; }

        public MembershipService(ISessionApiService sessionApiService)
        {
            _sessionApiServices = sessionApiService;
        }

        public async Task LoadUserData(string email, string password)
        {
            var userModel = await _sessionApiServices.SignInAsync(email, password);

            CurrentUser = userModel;
        

        }
    }
}
