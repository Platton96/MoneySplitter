using System;
using MoneySplitter.Infrastructure;

namespace MoneySplitter.Services.Api
{
    public  class ApiUrlBuilder : IApiUrlBuilder
    {
        public Uri Authorization()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Session.SESSION,
                Defines.Api.Session.SIGN_IN));
        }

        public Uri Registration()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Session.SESSION,
                Defines.Api.Session.REGISTER));
        }

        public Uri SearchUsers(string query)
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Users.USERS,
                Defines.Api.Users.SEARCH,
                Defines.Api.Users.SEARCH_PARAMETR,
                query));
        }
    }

}
