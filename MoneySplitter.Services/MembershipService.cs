using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Infrastructure;
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

        public async Task<bool> SingInAndLoadUserDataAsync(string email, string password)
        {
            var executionResult = await _sessionApiServices.SignInAsync(email, password);

            CurrentUser = executionResult.Result;

            return executionResult.IsSuccess;
        }

        public async Task<bool> ReisterAndLoadUserDataAsync(RegisterModel registerModel)
        {
            var executionResult = await _sessionApiServices.RegisterAsync(registerModel);

            CurrentUser = executionResult.Result;

            return executionResult.IsSuccess;
        }
    }
}
