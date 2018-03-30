using System;

namespace MoneySplitter.Services.API
{
    public  class ApiUrlBuilder
    {
        private const string WebApiUrl = "http://moneytransfer.azurewebsites.net";

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
