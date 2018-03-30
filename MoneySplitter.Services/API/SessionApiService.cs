using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MoneySplitter.Models;
using System.Net;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Infrastructure;
namespace MoneySplitter.Services.Api
{
    public class SessionApiService : ISessionApiService
    {
        private readonly ApiUrlBuilder _builderURL;

        public SessionApiService()
        {
            _builderURL = new ApiUrlBuilder();
        }

        public async Task<UserModel> SignInAsync(string email, string password)
        {
            var loginModel = new LoginModel
            {
                Email = email,
                Password = password
            };

            var signInUri = _builderURL.Authorization();

            var result = new UserModel();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
                var responce = await httpClient.PostAsync(signInUri, content);

                if (responce.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                 var contentResponce = await responce.Content.ReadAsStringAsync();
                 result = JsonConvert.DeserializeObject<UserModel>(contentResponce);
            }

            return result;
        }

    }
}
