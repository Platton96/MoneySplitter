using MoneySplitter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface ITransactionsManager
    {
        Task<bool> LoadUserTransactionsAsync();
        IEnumerable<TransactionModel> UserTransactions { get; }
        Task<bool> AddTransactionAsync(AddTransactionModel addTransactionModel);
        Task<bool> MoveUserToInProgress(int transactionId);
        Task<bool> MoveUserToFinished(int transactionId, int userId);
    }
}
