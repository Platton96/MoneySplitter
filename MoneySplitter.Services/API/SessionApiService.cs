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

        public SessionApiService(IApiUrlBuilder urlBuilder)
        {
            _urlBuilder = urlBuilder;
        }

        public async Task<UserModel> SignInAsync(string email, string password)
        {
            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var signInUri = _urlBuilder.Authorization();

            var dataUser = new DataUser();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
                var responce = await httpClient.PostAsync(signInUri, content);

                if (responce.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                 var contentResponce = await responce.Content.ReadAsStringAsync();
                 dataUser = JsonConvert.DeserializeObject<DataUser>(contentResponce);
            }

            var userModel =new UserModel
            {
                Id = dataUser.Id,
                Name = dataUser.Name,
                Surname = dataUser.Surname,
                Email = dataUser.Email,
                PhoneNumber = dataUser.PhoneNumber,
                CreditCardNumber = dataUser.CreditCardNumber,
                Ballance = dataUser.Ballance
            };
            return userModel;
        }

        //public async Task<DataUser> RegistrAsync(RegistrModel registrModel)
        //{
        //    var regisrUri = _urlBuilder.Registration();

        //    var result = new DataUser();

        //    using (var httpClient = new HttpClient())
        //    {
        //        var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
        //        var responce = await httpClient.PostAsync(signInUri, content);

        //        if (responce.StatusCode != HttpStatusCode.OK)
        //        {
        //            return null;
        //        }

        //        var contentResponce = await responce.Content.ReadAsStringAsync();
        //        result = JsonConvert.DeserializeObject<DataUser>(contentResponce);
        //    }

        //    return result;
        //}

    }
}
