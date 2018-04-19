using System;
using System.Threading.Tasks;

namespace MoneySplitter.Services
{
    public class Executor
    {
        public async Task<bool> ExecuteWithRetryAsync(Func<Task> asyncAction)
        {
            await 
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
