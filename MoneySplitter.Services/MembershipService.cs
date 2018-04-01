using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Services.Api;
using MoneySplitter.Infrastructure;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Models.Session;

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

        public async Task SingInAndLoadUserDataAsync(string email, string password)
        {
            var userModel = await _sessionApiServices.SignInAsync(email, password);

            CurrentUser = userModel;

        }

        public async Task ReistrAndLoadUserDataAsync(RegistrModel registrModel)
        {
            var userModel = await _sessionApiServices.RegistrAsync(registrModel);

            CurrentUser = userModel;
        }
    }
}
