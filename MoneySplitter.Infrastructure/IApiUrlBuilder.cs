using System;

namespace MoneySplitter.Infrastructure
{
    public interface IApiUrlBuilder
    {
        Uri Authorization();
        Uri Register();
        Uri SearchUsers(string query);
        Uri AddFriend();
        Uri AllFriends();
        Uri RemoveFriend();
        Uri AddTransaction();
        Uri AllUserTransactions();
        Uri AllTransactions();
    }
}
