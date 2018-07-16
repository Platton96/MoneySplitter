using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface ITransactionsApiService
    {
        Task<ExecutionResult<IEnumerable<TransactionModel>>> GetAllUserTransactionsAsync();
        Task<ExecutionResult<IEnumerable<TransactionModel>>> GetAllUserTransactionsAsync(int friendId);
        Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel);
        Task<bool> MoveUserToInProgressAsync(int transactionId);
        Task<bool> MoveUserToFineshedAsync(int transactionId, int userId);
        Task<bool> ApproveAllAsync(int friendId);
    }
}
