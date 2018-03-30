using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Models.Session;
using System.Net;

namespace MoneySplitter.Services.API
{
    public class SessionApiService
    {
        private readonly ApiUrlBuilder _builderURL;
        public SessionApiService()
        {
            _builderURL = new ApiUrlBuilder();
        }
        public async Task<UserModel> SignIn(string email, string password)
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
