using MoneySplitter.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Services.Api
{
    public class QueryApiService : IQueryApiService
    {
        public async Task<TResultQuery> PostAsync<TResultQuery, TBodyQuery>(Uri uri, TBodyQuery bodyQuery)
            where TResultQuery : class
            where TBodyQuery : class
        {
            TResultQuery resultQuery;
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(bodyQuery), Encoding.UTF8, "application/json");
                var responce = await httpClient.PostAsync(uri, content);

                resultQuery =await GetContentResponce<TResultQuery>(responce);
            }

            return resultQuery;
        }

        public async Task<bool> PostAsync<TBodyQuery>(Uri uri, TBodyQuery bodyQuery)
            where TBodyQuery : class
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.AddCredentials();
               var content = new StringContent(JsonConvert.SerializeObject(bodyQuery), Encoding.UTF8, "application/json");
                var responce = await httpClient.PostAsync(uri, content);

                if (responce.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<TResultQuery> GetAsync<TResultQuery>(Uri uri)
            where TResultQuery : class
        {
            TResultQuery resultQuery;
            using (var httpClient = new HttpClient())
            {
                httpClient.AddCredentials();
                var responce = await httpClient.GetAsync(uri);
                resultQuery = await GetContentResponce<TResultQuery>(responce);
            }

            return resultQuery;
        }

        private async Task<TContentResponce> GetContentResponce<TContentResponce>(HttpResponseMessage responseMessage)
            where TContentResponce : class
        {
            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(Defines.ServerMassage.BAD_RESPONCE);
            }

            var contentResponce = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TContentResponce>(contentResponce);
        }

        public async Task<bool> PostAsync(Uri uri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.AddCredentials();
                var content = new StringContent("");
                var responce = await httpClient.PostAsync(uri, content);

                if (responce.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<TResultQuery> PostAsync<TResultQuery>(Uri uri)
            where TResultQuery : class
        {
            TResultQuery resultQuery;
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent("");
                var responce = await httpClient.PostAsync(uri, content);

                resultQuery = await GetContentResponce<TResultQuery>(responce);
            }

            return resultQuery;
        }

    }
}


