using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface ISearchApiService
    {
        Task<IEnumerable<UserModel>> SearchUsersAsync(string query);
    }
}
