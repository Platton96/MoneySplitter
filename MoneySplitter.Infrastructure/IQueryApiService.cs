﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySplitter.Infrastructure
{
    public interface IQueryApiService<TResult, TBodyQuery> 
        where TResult : class
        where TBodyQuery : class 
    {
        
    }
}
