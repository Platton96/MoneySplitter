using System;
using System.Linq;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models.Services;

namespace MoneySplitter.Services.Api
{
    public class ApiUrlBuilder : IApiUrlBuilder
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
                CreateQueryParameter(Defines.Api.Users.SEARCH_PARAMETR, query)));
        }

        public Uri AddFriend(int friendId)
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Friends.FRIENDS,
                Defines.Api.Friends.ADD_FRIEND,
                CreateQueryParameter(Defines.Api.Friends.FRIEND_ID, friendId)));
        }

        public Uri RemoveFriend(int friendId)
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Friends.FRIENDS,
                Defines.Api.Friends.REMOVE_FRIEND,
                CreateQueryParameter(Defines.Api.Friends.FRIEND_ID, friendId)));
        }

        public Uri AllFriends()
        {
            return new Uri(string.Concat(
             Defines.Api.WEB_API_URL,
             Defines.Api.Friends.FRIENDS,
             Defines.Api.Friends.ALL_FRIENDS));
        }

        public Uri AllUserTransactions()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.MY));
        }

        public Uri AllUserTransactions(int friendId)
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.MY,
                CreateQueryParameter(Defines.Api.Transactions.BY_USER_ID, friendId)));
        }

        public Uri AddTransaction()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.ADD));
        }

        public Uri AllTransactions()
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.ALL));
        }

        public Uri Collaborate(int transactionId)
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.COLLABORATE,
                CreateQueryParameter(Defines.Api.Transactions.Parameters.ID, transactionId)));
        }

        public Uri Approve(int transactionId, int userId)
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.APPROVE,
                CreateQueryParameters(
                    new QueryParameterModel
                    {
                        ParameterName = Defines.Api.Transactions.Parameters.TRANSACTION_ID,
                        ParameterValue = transactionId.ToString()
                    },
                    new QueryParameterModel
                    {
                        ParameterName = Defines.Api.Transactions.Parameters.USER_ID,
                        ParameterValue = userId.ToString()
                    }
               )
             ));
        }

        public Uri ApproveAll (int friendId)
        {
            return new Uri(string.Concat(
                Defines.Api.WEB_API_URL,
                Defines.Api.Transactions.TRANSACTIONS,
                Defines.Api.Transactions.APPROVEALL,
                CreateQueryParameter(Defines.Api.Transactions.FRIEND_ID, friendId)));
        }

        private string CreateQueryParameter(string parameterName, object parameterValue)
        {
            return $"?{parameterName}={parameterValue}";
        }

        private string CreateQueryParameters(params QueryParameterModel[] parameters)
        {
            return "?" + string.Join("&", parameters.Select(pr => pr.ParameterName +"="+ pr.ParameterValue));
        }
    }
}
