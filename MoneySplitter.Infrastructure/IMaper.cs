using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySplitter.Infrastructure
{
    public interface IMaper<TResult,TParametr> 
        where TResult : class
        where TParametr : class
    {
        TResult ToConvert(TParametr parametr);
    }
}
