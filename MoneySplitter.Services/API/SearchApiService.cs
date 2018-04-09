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
        private readonly IApiUrlBuilder _apiUrlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _maper;

        public SearchApiService(IApiUrlBuilder apuUrlBuilder, IQueryApiService queryApiService, IMapper maper)
        {
            _apiUrlBuilder = apuUrlBuilder;
            _queryApiService = queryApiService;
            _maper = maper;
        }

        public async Task<IEnumerable<UserModel>> SearchUsersAsync(string query)
        {
            var searchUsersUri = _apiUrlBuilder.SearchingUsers(query);

            var usersData = await _queryApiService.GetAsync<IEnumerable<DataUser>>(searchUsersUri);

            return usersData.Select(x => _maper.ConvertDataUserToUserModel(x));
        }
    }
}
