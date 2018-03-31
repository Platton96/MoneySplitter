using System;
using MoneySplitter.Infrastructure;

namespace MoneySplitter.Services.Api
{
    public  class ApiUrlBuilder : IApiUrlBuilder
    {
        private const string WebApiUrl = "http://moneytransfer.azurewebsites.net";

        public Uri Authorization()
        {
            return new Uri(string.Concat(
                WebApiUrl,
                Defines.Api.Session.SESSION,
                Defines.Api.Session.SIGN_IN));
        }

        public Uri Registration()
        {
            return new Uri(string.Concat(
                WebApiUrl,
                Defines.Api.Session.SESSION,
                Defines.Api.Session.REGISTR));
        }
    }

}
