using System;
using System.Collections.Generic;
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
        private readonly ApiBuilderURL _builderURL;
        public SessionApiService()
        {
            _builderURL = new ApiBuilderURL();
        }
        public async Task<UserModel> SignIn(LoginModel loginModel)
        {
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

                 var jsonLogin = await responce.Content.ReadAsStringAsync();
                 result = JsonConvert.DeserializeObject<UserModel>(jsonLogin);
            }

            return result;
        }
    }
}
