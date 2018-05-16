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

        public async Task<bool> LoadUserTransactionsAsync()
        {
            var executionResult = await _transactionsApiService.GetAllUserTransactions();
            UserTransactions = executionResult.Result;

            return executionResult.IsSuccess;
        }

        public async Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel)
        {
            return await _transactionsApiService.AddTransactionAsync(addTransactionModel);
        }

        public async Task<bool> MoveUserToInProgress(int transactionId)
        {
            return await _transactionsApiService.MoveUserToInProgress(transactionId);
        }

        public async Task<bool> MoveUserToFinished(int transactionId, int userId)
        {
            return await _transactionsApiService.MoveUserToFineshed(transactionId, userId);
        }
    }
}
