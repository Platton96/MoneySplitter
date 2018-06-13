using System.Reflection;
using System.Resources;

namespace MoneySplitter.Win10.Common
{
    public class LocalisationServise
    {
        private  ResourceManager _resourseManger;

        public LocalisationServise(string path)
        {
            InitializeResurceManger(path);
        }

        public void InitializeResurceManger(string path)
        {
            _resourseManger = new ResourceManager(path,
              Assembly.GetExecutingAssembly());
        }



    }
}
