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
        private readonly IExecutor _executor;

        public SearchApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper, IExecutor executor)
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
            _executor = executor;
        }

        public async Task<ExecutionResult<IEnumerable<UserModel>>> SearchUsersAsync(string query)
        {
            var result = new ExecutionResult<IEnumerable<UserModel>>
            {
                IsSuccess = false
            };

            var apiUrlSearchUsers = _apiUrlBuilder.SearchUsers(query);

            IEnumerable<UserData> usersData = null;

            await _executor.ExecuteWithRetryAsync(async () =>
            {
                usersData = await _queryApiService.GetAsync<IEnumerable<UserData>>(apiUrlSearchUsers);
            });

            if (usersData == null)
            {
                return result;
            }

            return new ExecutionResult<IEnumerable<UserModel>>
            {
                IsSuccess = true,
                Result = usersData.Select(x => _mapper.ConvertDataUserToUserModel(x)).ToList()
            };

        }
    }
}
