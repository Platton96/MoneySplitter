using MoneySplitter.Infrastructure;
using System;
using System.Threading.Tasks;

namespace MoneySplitter.Services
{
    public class Executor : IExecutor
    {
        public async Task<bool> ExecuteWithRetryAsync(Func<Task> asyncAction)
        {
            for (int i = 0; i < Defines.Executor.COUNT_TRY; i++)
            {
                var isSuccessResult = await ExecuteOneTime(asyncAction);

                if(isSuccessResult)
                {
                    return true;
                }
            }

            return false;

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
