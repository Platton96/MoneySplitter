using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Services.Api
{
    public class TransactionsApiService : ITransactionsApiService
    {
        private readonly IApiUrlBuilder _apiUrlBuilder;
        private readonly IQueryApiService _queryApiService;
        private readonly IMapper _mapper;
        private readonly IExecutor _executor;

        public TransactionsApiService(IApiUrlBuilder apiUrlBuilder, IQueryApiService queryApiService, IMapper mapper, IExecutor executor)
        {
            _apiUrlBuilder = apiUrlBuilder;
            _queryApiService = queryApiService;
            _mapper = mapper;
            _executor = executor;
        }

        public async Task<ExecutionResult<IEnumerable<TransactionModel>>> GetAllUserTransactions()
        {
            var result = new ExecutionResult<IEnumerable<TransactionModel>>
            {
                IsSuccess = false
            };

            var allUserTransactionsUrl = _apiUrlBuilder.AllUserTransactions();

            IEnumerable<TransactionData> userTransactionsData = null;

            await _executor.ExecuteWithRetryAsync((async () =>
            {
                userTransactionsData = await _queryApiService.GetAsync<IEnumerable<TransactionData>>(allUserTransactionsUrl);
            }));

            if (userTransactionsData == null)
            {
                return result;
            }

            result.Result =
                userTransactionsData.Select(x => _mapper.ConvertTransactioDataToTransactionModel(x)).ToList();

            result.IsSuccess = true;
            return result;
        }

        public async Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel)
        {
            var addTransactiodUrl = _apiUrlBuilder.AddTransaction();

            var addTransactionData = _mapper.ConvertAddTransactioModelToAddTransactionData(addTransactionModel);

            return await _queryApiService.PostAsync(addTransactiodUrl, addTransactionData);
        }

        public async Task<bool> MoveUserToInProgress(int transactionId)
        {
            var collabarateUrl = _apiUrlBuilder.Collabarate(transactionId);

            return await _queryApiService.PostAsync(collabarateUrl);
        }

        public async Task<bool> MoveUserToFineshed(int transactionId, int userId)
        {
            var approveTransactionUrl = _apiUrlBuilder.Approve(transactionId, userId);

            return await _queryApiService.PostAsync(approveTransactionUrl);
        }

    }
}
