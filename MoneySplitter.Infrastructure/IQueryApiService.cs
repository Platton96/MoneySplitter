using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySplitter.Infrastructure
{
    public interface IQueryApiService<Result, BodyQuery> 
        where Result : class
        where BodyQuery : class 
    {
        
    }
}
