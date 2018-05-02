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

        public Uri Register()
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

        public Uri AddFriend()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Friends.FRIENDS,
                Defines.Api.Friends.ADD_FRIEND));
        }

        public Uri RemoveFriend()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Friends.FRIENDS,
                Defines.Api.Friends.REMOVE_FRIEND));
        }

        public Uri GetAllFriends()
        {
            return new Uri(string.Concat(
             Defines.Api.WEB_API_URL,
             Defines.Api.Friends.FRIENDS,
             Defines.Api.Friends.ALL_FRIENDS));
        }

        public Uri GetAllUserTransactions()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.MY));
        }

        public Uri AddTransaction()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.ADD));
        }

        public Uri GetAllTransactions()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.ALL));
        }
    }
}
