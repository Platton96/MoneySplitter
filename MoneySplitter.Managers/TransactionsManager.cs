using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Managers
{
    public class TransactionsManager : ITransactionsManager
    {
        private readonly ITransactionsApiService _transactionsApiService;

        public TransactionsManager(ITransactionsApiService transactionsApiService)
        {
            _transactionsApiService = transactionsApiService;
        }

        public async Task<ExecutionResult<IEnumerable<TransactionModel>>> GetUserTransactionsAsync()
        {
            return await _transactionsApiService.GetAllUserTransactionsAsync();
        }

        public async Task<ExecutionResult<IEnumerable<TransactionModel>>> GetFriendTransactionsAsync(int friendId)
        {
            return await _transactionsApiService.GetAllUserTransactionsAsync(friendId);
        }

        public async Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel)
        {
            return await _transactionsApiService.AddTransactionAsync(addTransactionModel);
        }

        public async Task<bool> MoveUserToInProgressAsync(int transactionId)
        {
            return await _transactionsApiService.MoveUserToInProgressAsync(transactionId);
        }

        public async Task<bool> MoveUserToFinishedAsync(int transactionId, int userId)
        {
            return await _transactionsApiService.MoveUserToFineshedAsync(transactionId, userId);
        }
        
        public async Task<bool> ApproveAllAsync(int friendId)
        {
            return await _transactionsApiService.ApproveAllAsync(friendId);
        }
    }
}
