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
        public async Task<TResultQuery> PostAsync<TResultQuery, TBodyQuery>(TBodyQuery bodyQuery, Uri uri)
            where TResultQuery : class
            where TBodyQuery : class
        {
            TResultQuery resultQuery;
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(bodyQuery), Encoding.UTF8, "application/json");
                var responce = await httpClient.PostAsync(uri, content);

                if (responce.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                var contentResponce = await responce.Content.ReadAsStringAsync();
                resultQuery = JsonConvert.DeserializeObject<TResultQuery>(contentResponce);
            }

            return resultQuery;
        }

        public async Task<bool> PostAsync<TBodyQuery>(TBodyQuery bodyQuery, Uri uri)
            where TBodyQuery : class
        {
            using (var httpClient = new HttpClient())
            {
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
                var responce = await httpClient.GetStringAsync(uri);
                resultQuery = JsonConvert.DeserializeObject<TResultQuery>(responce);
            }

            return resultQuery;
        }
    }
}
