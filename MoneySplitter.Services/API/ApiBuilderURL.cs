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

        public Uri Authorization()
        {
            return new Uri(string.Concat(
                WebApiUrl,
                Defines.Api.Session.SESSION,
                Defines.Api.Session.SIGN_IN));
        }
    }

    public static class Defines
    {
        public static class Api
        {
            public static class Session
            {
                public const string SIGN_IN = "/signin";
                public const string SESSION = "/session";
            }
        }
    }
}
