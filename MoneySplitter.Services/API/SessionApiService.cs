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

            var dataUser = await _queryApiService.PostAsync<DataUser, LoginModel>(loginModel, apiUrlSignIn);

            return _mapper.ConvertDataUserToUserModel(dataUser);
        }

        public async Task<UserModel> RegisterAsync(RegisterModel registerModel)
        {
            var apiUrlRegister = _apiUrlBuilder.Register();

            var dataRegisterUser = _mapper.ConvertRegisterModelToDataRegisterUser(registerModel);

            var dataUser = await _queryApiService.PostAsync<DataUser, DataRegisterUser>(dataRegisterUser, apiUrlRegister);

            return _mapper.ConvertDataUserToUserModel(dataUser);
        }
    }
}
