using System;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IExecutor
    {
        Task<bool> ExecuteWithRetryAsync(Func<Task> asyncAction);
        Task<bool> ExecuteOneTime(Func<Task> asyncAction);
    }
}
