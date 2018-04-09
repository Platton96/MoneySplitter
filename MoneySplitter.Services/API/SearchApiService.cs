using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Services.API
{
    public class SearchApiService : ISearchApiService
    {
        private readonly IApiUrlBuilder _urlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _maper;

        public SearchApiService(IApiUrlBuilder urlBuilder, IQueryApiService queryApiService, IMapper maper)
        {
            _urlBuilder = urlBuilder;
            _queryApiService = queryApiService;
            _maper = maper;
        }

        public async Task<IEnumerable<UserModel>> SearchUsersAsync(string query)
        {
            var searchUsersUri = _urlBuilder.SearchUsers(query);

            var dataUsers = await _queryApiService.GetAsync<IEnumerable<DataUser>>(searchUsersUri);

            return dataUsers.Select(x => _maper.ConvertDataUserToUserModel(x));
        }
    }
}
