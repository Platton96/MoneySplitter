using System;

namespace MoneySplitter.Infrastructure
{
    public interface IApiUrlBuilder
    {
        Uri Authorization();
        Uri Registration();
        Uri SearchingUsers(string query);
        Uri AdditionFriend();
        Uri GetAllFriends();
    }
}
