using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MoneySplitter.Models.Session;
using System.Net;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;

namespace MoneySplitter.Services.Api
{
    public class SessionApiService : ISessionApiService
    {
        private readonly IApiUrlBuilder _urlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMaper _maper;

        public SessionApiService(IApiUrlBuilder urlBuilder, IQueryApiService queryApiService, IMaper maper)
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

            return _maper.ToConvertUserModel(dataUser);
        }

        public async Task<UserModel> RegistrAsync(RegistrModel registrModel)
        {
            var regisrUri = _urlBuilder.Registration();

            var dataUser = await _queryApiService.PostQueryAsync<DataUser, RegistrModel>(registrModel, regisrUri);

            return _maper.ToConvertUserModel(dataUser);
        }

    }
}
