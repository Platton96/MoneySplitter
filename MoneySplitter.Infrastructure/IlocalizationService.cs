using System;

namespace MoneySplitter.Infrastructure
{
    public interface ILocalizationService
    {
        void InitializeStrings(string path);
        string GetString(string key);
        string GetString(Enum key);
    }
}
