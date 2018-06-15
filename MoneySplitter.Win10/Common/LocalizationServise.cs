using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Xml.Linq;
using MoneySplitter.Models;
using Windows.ApplicationModel.Resources;

namespace MoneySplitter.Win10.Common
{
    public class LocalizationServise
    {
        private ResourceLoader _resourceLoader;
        IDictionary<string, string> Strings { get; set; }

        public LocalizationServise()
        {
        }

        public void InitializeResurceManger(string path)
        {
        }

        //public string GetString(string key)
        //{
           
        //}

        public void InitializeStrings()
        {
            var a = File.ReadAllText(@"D:\Projects\MoneySplitter\MoneySplitter.Win10\Strings\just.txt");
            
          
            

            //var file = XDocument.Load(@"D:\Projects\MoneySplitter\MoneySplitter.Win10\Strings\Ru.resw");
        }

    }
}
