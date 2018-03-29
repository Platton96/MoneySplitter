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
    public class SessionApiServices
    {
        private readonly string _urlSession;
        private ApiBuilderURL _builderURL;
        public SessionApiServices()
        {
            _builderURL = new ApiBuilderURL();
            _urlSession = _builderURL.AddController("Session");
        }
        public async Task<UserModel> SignIn(LoginModel loginModel)
        {
            var signInUri = new Uri(_builderURL.AddMethodOfController(_urlSession, "SignIn"));
            var result = new UserModel();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
                var responce = await httpClient.PostAsync(signInUri, content);
                if (responce.StatusCode == HttpStatusCode.OK)
                {
                    var jsonLogin = await responce.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<UserModel>(jsonLogin);
                }
                else
                {
                    result=null;
                }
            }

            return result;
        }
    }
}
