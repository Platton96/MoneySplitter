using System;

namespace MoneySplitter.Infrastructure
{
    public interface IApiUrlBuilder
    {
        Uri Authorization();
        Uri Registration();
        Uri SearchUsers(string query);
    }
}
