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

        public SessionApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper, IExecutor executor )
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
            _executor = executor;
        }

        public async Task<ExecutionResult<UserModel>> SignInAsync(string email, string password)
        {
            ExecutionResult<UserModel> result = new ExecutionResult<UserModel>
            {
                IsSuccess = false
            };

            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var apiUrlSignIn = _apiUrlBuilder.Authorization();

            UserData userData = null;
            await _executor.ExecuteWithRetryAsync(async () =>
            {
                userData = await _queryApiService.PostAsync<UserData, LoginModel>(loginModel, apiUrlSignIn);
            });

            var userModel = _mapper.ConvertDataUserToUserModel(userData);

            if (userModel == null)
            {
                return result;
            }

            result.Result = userModel;
            result.IsSuccess = true;

            return result;
        }

        public async Task<UserModel> RegisterAsync(RegisterModel registerModel)
        {
            var apiUrlRegister = _apiUrlBuilder.Register();

            var registerUserData = _mapper.ConvertRegisterModelToDataRegisterUser(registerModel);

            var userData = await _queryApiService.PostAsync<UserData, RegisterUserData>(registerUserData, apiUrlRegister);

            return _mapper.ConvertDataUserToUserModel(userData);
        }
    }
}
