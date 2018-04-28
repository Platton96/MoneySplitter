using System;

namespace MoneySplitter.Infrastructure
{
    public interface IApiUrlBuilder
    {
        Uri Authorization();
        Uri Register();
        Uri SearchUsers(string query);
        Uri AddFriend();
        Uri GetAllFriends();
        Uri RemoveFriend();
        Uri AddTransaction();
        Uri GetAllMyTransactions();
        Uri GetAllTransactions();
    }
}
