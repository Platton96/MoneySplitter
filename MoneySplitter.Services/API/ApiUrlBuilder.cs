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


}
