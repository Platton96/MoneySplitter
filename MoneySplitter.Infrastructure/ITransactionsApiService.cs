using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface ITransactionsApiService
    {
        Task<ExecutionResult<IEnumerable<TransactionModel>>> GetAllUserTransactions();
        Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel);
        Task<bool> MoveUserToInProgressAsync(int transactionId);
        Task<bool> MoveUserToFineshedAsync(int transactionId, int userId);
    }
}
