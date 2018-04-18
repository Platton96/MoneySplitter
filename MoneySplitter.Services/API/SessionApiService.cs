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

        public SessionApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper)
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
        }

        public async Task<UserModel> SignInAsync(string email, string password)
        {
            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var apiUrlSignIn = _apiUrlBuilder.Authorization();

            var userData = await _queryApiService.PostAsync<UserData, LoginModel>(loginModel, apiUrlSignIn);

            return _mapper.ConvertDataUserToUserModel(userData);
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
