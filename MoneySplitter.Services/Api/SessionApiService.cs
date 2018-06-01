using System.Threading.Tasks;
using MoneySplitter.Models.Session;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Services.Inerfaces;

namespace MoneySplitter.Services.Api
{
    public class SessionApiService : ISessionApiService
    {
        private readonly IApiUrlBuilder _apiUrlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _mapper;
        private readonly IExecutor _executor;

        public SessionApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper, IExecutor executor)
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
            _executor = executor;
        }

        public async Task<ExecutionResult<UserModel>> SignInAsync(string email, string password)
        {
            var result = new ExecutionResult<UserModel>
            {
                IsSuccess = false
            };

            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var signInUrl = _apiUrlBuilder.Authorization();

            UserData userData = null;
            await _executor.ExecuteWithRetryAsync(async () =>
            {
                userData = await _queryApiService.PostAsync<UserData, LoginModel>(signInUrl, loginModel);
            });

            var userModel = _mapper.ConvertUserDataToUserModel(userData);

            if (userModel == null)
            {
                return result;
            }

            result.Result = userModel;
            result.IsSuccess = true;

            return result;
        }

        public async Task<ExecutionResult<UserModel>> RegisterAsync(RegisterModel registerModel)
        {
            var result = new ExecutionResult<UserModel>
            {
                IsSuccess = false
            };

            var registerUrl = _apiUrlBuilder.Register();

            UserData userData = null;

            var registerUserData = _mapper.ConvertRegisterModelToRegisterUserData(registerModel);

            await _executor.ExecuteWithRetryAsync(async () =>
            {
                userData = await _queryApiService.PostAsync<UserData, RegisterUserData>(registerUrl, registerUserData);
            });

            var userModel = _mapper.ConvertUserDataToUserModel(userData);
            if (userModel == null)
            {
                return result;
            }

            result.Result = userModel;
            result.IsSuccess = true;

            return result;
        }
    }
}
