using MoneySplitter.Infrastructure;
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
        public IDictionary<string, string> Strings { get; private set; }

        public void InitializeStrings(string path)
        {
            Strings = LoadStringsForLocale(path);
        }

        public Dictionary<string, string> LoadStringsForLocale(string path)
        {
            var folder = ApplicationData.Current.LocalFolder.Path;
            var xmlRepresentation = File.ReadAllText(Package.Current.InstalledLocation.Path + path);

            return
                XDocument.Parse(xmlRepresentation)
                .Descendants()
                .Elements("data")
                .ToDictionary(key => key.FirstAttribute.Value, value => (string)value.Element("value"));
        }

    }
}
