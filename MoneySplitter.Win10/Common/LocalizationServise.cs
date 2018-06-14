using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using MoneySplitter.Models;
using Windows.ApplicationModel.Resources;

namespace MoneySplitter.Win10.Common
{
    public class LocalizationServise
    {
        private ResourceLoader _resourceLoader;
        IDictionary<DefinesStringKeys, string> Strings { get; set; }

        public LocalizationServise()
        {
        }

        public void InitializeResurceManger(string path)
        {
            _resourceLoader.GetForCurrentView();

            public string GetString(string key)
        {
            return _resourseManger.GetString(key);
        }

        public void InitializeStrings()
        {
            foreach (DefinesStringKeys key in Enum.GetValues(typeof(DefinesStringKeys)))
            {
                Strings.Add(key, GetString(key.ToString()));
            }
        }
    }
}
