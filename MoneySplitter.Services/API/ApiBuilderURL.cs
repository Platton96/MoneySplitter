using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySplitter.Services.API
{
    public  class ApiBuilderURL
    {
        private const string WebApiUrl = "http://moneytransfer.azurewebsites.net";

        public string AddController (string nameController)
        {
            return WebApiUrl + "/" + nameController;
        }

        public string AddControllerAndmethod (string nameController, string nameMethod)
        {
            return WebApiUrl + "/" + nameController + "/" + nameMethod;
        }
        public string AddMethodOfController(string urlController, string nameMethod)
        {
            return  urlController + "/" + nameMethod;
        }
    }
}
