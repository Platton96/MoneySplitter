using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Services.Api
{
    public class SearchApiService : ISearchApiService
    {
        private readonly IApiUrlBuilder _apiUrlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _mapper;

        public SearchApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper)
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> SearchUsersAsync(string query)
        {
            var apiUrlSearchUsers = _apiUrlBuilder.SearchUsers(query);

            var usersData = await _queryApiService.GetAsync<IEnumerable<DataUser>>(apiUrlSearchUsers);

            return usersData.Select(x => _mapper.ConvertDataUserToUserModel(x)).ToList();
        }
    }
}
