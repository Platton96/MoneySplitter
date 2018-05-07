using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Managers
{
    public class TransactionsManager : ITransactionsManager
    {
        private ITransactionsApiService _transactionsApiService;
        
        public IEnumerable<TransactionModel> UserTransactions { get; private set; }

        public TransactionsManager(ITransactionsApiService transactionsApiService)
        {
            _transactionsApiService = transactionsApiService;
        }

        public async Task<bool> LoadUserTransactions()
        {
            var executionResult = await _transactionsApiService.GetAllUserTransactions();
            UserTransactions = executionResult.Result;

            return executionResult.IsSuccess;
        }

        public async Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel)
        {
            return await _transactionsApiService.AddTransactionAsync(addTransactionModel);
        }
    }
}
