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
            for (int i = 0; i < Defines.Executor.EXECUTION_ATTEMPTS_COUNT; i++)
            {
                if(await ExecuteOneTime(asyncAction))
                {
                    return;
                }
            }
        }

        public async Task<bool> ExecuteOneTime(Func<Task> asyncAction)
        {
            try
            {
                await asyncAction();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
