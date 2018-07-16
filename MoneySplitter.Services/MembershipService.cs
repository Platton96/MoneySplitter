using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.Session;
using MoneySplitter.Sqlite;

namespace MoneySplitter.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly ISessionApiService _sessionApiServices;
        private readonly ISessionRepository _sessionRepository;
        private readonly DbContext _dbContext;

        public UserModel CurrentUser { get;  private set; }

        public MembershipService(ISessionApiService sessionApiService, ISessionRepository sessionRepository, DbContext dbContext)
        {
            _sessionApiServices = sessionApiService;
            _sessionRepository = sessionRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> SingInAndLoadUserDataAsync(string email, string password)
        {
            var executionResult = await _sessionApiServices.SignInAsync(email, password);

            if (executionResult.IsSuccess)
            {
                CurrentUser = executionResult.Result;
                await _sessionRepository.AddUserAsync(CurrentUser);
            }

            return executionResult.IsSuccess;
        }

        public async Task<bool> ReisterAndLoadUserDataAsync(RegisterModel registerModel)
        {
            var executionResult = await _sessionApiServices.RegisterAsync(registerModel);

            if (executionResult.IsSuccess)
            {
                CurrentUser = executionResult.Result;
                await _sessionRepository.AddUserAsync(CurrentUser);
            }

            return executionResult.IsSuccess;
        }

        public async Task LogoutAsync()
        {
            await InitializeDbAsyns();
        }

        public async Task InitializeDbAsyns()
        {
            await _dbContext.InitializeAsyns();
        }

        public async Task<bool> TryLoadUserFromDbAsync()
        {
            var userModel = await _sessionRepository.GetUserAsync();

            if (userModel == null)
            {
                return false;
            }

            CurrentUser = userModel;
            return true;
        }
    }
}
