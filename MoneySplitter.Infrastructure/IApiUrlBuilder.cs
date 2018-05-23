using System;

namespace MoneySplitter.Infrastructure
{
    public interface IApiUrlBuilder
    {
        Uri Authorization();
        Uri Register();
        Uri SearchUsers(string query);
        Uri AddFriend(int friendId);
        Uri AllFriends();
        Uri RemoveFriend(int friendId);
        Uri AddTransaction();
        Uri AllUserTransactions();
        Uri AllUserTransactions(int friendId);
        Uri AllTransactions();
        Uri Collaborate(int transactionId);
        Uri Approve(int transactionId, int userId);
    }
}
