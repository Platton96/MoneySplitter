using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.Common
{
    public class LocalisationServise
    {
        private readonly ResourceManager _resourseManger;

        public LocalisationServise()
        {
            _resourseManger=new ResourceManager("UsingRESX.Strings/Ru",
                Assembly.GetExecutingAssembly());
        }
    }
}
