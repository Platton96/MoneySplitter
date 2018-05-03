using System;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IExecutor
    {
        Task ExecuteWithRetryAsync(Func<Task> asyncAction);
        Task<bool> ExecuteOneTime(Func<Task> asyncAction);
    }
}
