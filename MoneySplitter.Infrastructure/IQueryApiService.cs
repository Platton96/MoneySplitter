using System;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IQueryApiService
    {
        Task<TResultQuery> PostAsync<TResultQuery, TBodyQuery>(Uri uri, TBodyQuery bodyQuery)
            where TResultQuery : class
            where TBodyQuery : class;

        Task<TResultQuery> GetAsync<TResultQuery>(Uri uri)
            where TResultQuery : class;

        Task<bool> PostAsync(Uri uri);

        Task<TResultQuery> PostAsync<TResultQuery>(Uri uri)
            where TResultQuery : class;

        Task<bool> PostAsync<TBodyQuery>(Uri uri, TBodyQuery bodyQuery)
            where TBodyQuery : class;
    }
}
