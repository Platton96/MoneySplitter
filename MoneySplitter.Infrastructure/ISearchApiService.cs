using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface ISearchApiService
    {
        Task<IEnumerable<UserModel>> SearchUsersAsync(string query);
    }
}
