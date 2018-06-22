using MoneySplitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Storage;

namespace MoneySplitter.Win10.Common
{
    public class LocalizationServise : ILocalizationService
    {
        private IDictionary<string, string> _strings;
        private IDictionary<string, string> _udefinedStrings;

        public LocalizationServise()
        {
            InitializeStrings(Defines.Localization.RESOURCE_RU_FILE_PATCH);
            _udefinedStrings = LoadStringsForLocale(Defines.Localization.RESOURCE_UDN_FILE_PATCH);
        }

        public void InitializeStrings(string path)
        {
            _strings = LoadStringsForLocale(path);
        }

        private Dictionary<string, string> LoadStringsForLocale(string path)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var xmlRepresentation = File.ReadAllText(Package.Current.InstalledLocation.Path + path);
            return
                XDocument.Parse(xmlRepresentation)
                .Descendants()
                .Elements("data")
                .ToDictionary(key => key.FirstAttribute.Value, value => (string)value.Element("value"));
        }

        public string GetString(string key)
        {
            if (!_strings.TryGetValue(key, out string value))
            {
                _udefinedStrings.TryGetValue(key, out value);
            }

            return value;
        }

        public string GetString(Enum key)
        {
            return GetString(key.ToString());
        }

    }
}
