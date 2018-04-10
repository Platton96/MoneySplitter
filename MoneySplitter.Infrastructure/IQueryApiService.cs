using System;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IQueryApiService
    {
       Task <TResultQuery> PostAsync<TResultQuery, TBodyQuery> (TBodyQuery bodyQuery, Uri uri)
            where TResultQuery : class
            where TBodyQuery : class ;

        Task<TResultQuery> GetAsync<TResultQuery>(Uri uri)
            where TResultQuery : class;

        Task<bool> PostAsync<TBodyQuery>(TBodyQuery bodyQuery, Uri uri)
             where TBodyQuery : class;
    }
}
