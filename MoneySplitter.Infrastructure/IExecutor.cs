using MoneySplitter.Models;
using System;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IExecutor
    {
        Task ExecuteWithRetryAsync(Func<Task> asyncAction);

        Task ExecuteOneTime(Func<Task> asyncAction);
    }
}
