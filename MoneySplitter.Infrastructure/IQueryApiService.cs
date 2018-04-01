using System;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IQueryApiService
    {
       Task <TResultQuery> PostQueryAsync<TResultQuery, TBodyQuery> (TBodyQuery bodyQuery, Uri uri)
            where TResultQuery : class
            where TBodyQuery : class ;
    }
}
