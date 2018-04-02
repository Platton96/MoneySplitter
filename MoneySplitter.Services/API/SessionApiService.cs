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
        private readonly IApiUrlBuilder _urlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _maper;

        public SessionApiService(IApiUrlBuilder urlBuilder, IQueryApiService queryApiService, IMapper maper)
        {
            _urlBuilder = urlBuilder;
            _queryApiService = queryApiService;
            _maper = maper;
        }

        public async Task<UserModel> SignInAsync(string email, string password)
        {
            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var signInUri = _urlBuilder.Authorization();

            var dataUser = await _queryApiService.PostQueryAsync<DataUser, LoginModel>(loginModel, signInUri);

            return _maper.ConvertDataUserToUserModel(dataUser);
        }

        public async Task<UserModel> RegistrAsync(RegisterModel registrModel)
        {
            var regisrUri = _urlBuilder.Registration();

            var dataRegisterUser = _maper.ConvertRegisterModelToDataRegisteUser(registrModel);

            var dataUser = await _queryApiService.PostQueryAsync<DataUser, DataRegisterUser>(dataRegisterUser, regisrUri);

            return _maper.ConvertDataUserToUserModel(dataUser);
        }
    }
}
