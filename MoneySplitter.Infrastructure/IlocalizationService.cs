﻿using System.Collections.Generic;

namespace MoneySplitter.Infrastructure
{
    public interface ILocalizationService
    {
        IDictionary<string, string> Strings { get; }
        void InitializeStrings(string path);
        Dictionary<string, string> LoadStringsForLocale(string path);
        string GetValue(string key);

    }
}
