using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System;
using System.Threading.Tasks;

namespace MoneySplitter.Services
{
    public class Executor : IExecutor
    {
        public async Task ExecuteWithRetryAsync(Func<Task> asyncAction)
        {
            for (int i = 0; i < Defines.Executor.COUNT_TRY; i++)
            {
                await ExecuteOneTime(asyncAction);
            }
        }

        public async Task ExecuteOneTime(Func<Task> asyncAction)
        {
            try
            {
                await asyncAction();
            }
            catch
            {
                
            }

        }

    }
}
