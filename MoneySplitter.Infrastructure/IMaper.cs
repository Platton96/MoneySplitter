using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySplitter.Infrastructure
{
    public interface IMaper<TParametr>
    {
        UserModel ToConvertUserModel(TParametr parametr);

            
    }
}
