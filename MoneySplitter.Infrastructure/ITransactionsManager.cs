using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface ITransactionsManager
    {
        Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel);
        Task<bool> MoveUserToInProgressAsync(int transactionId);
        Task<bool> MoveUserToFinishedAsync(int transactionId, int userId);
        Task<ExecutionResult<IEnumerable<TransactionModel>>> GetFriendTransactionsAsync(int friendId);
        Task<ExecutionResult<IEnumerable<TransactionModel>>> GetUserTransactionsAsync();
        Task<bool> ApproveAllAsync(int friendId);
    }
}
