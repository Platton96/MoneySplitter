using System;
using System.Web;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class MenuItemTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var index = int.Parse(parameter.ToString());
            var str = value.ToString();

            var indexOfFirstSpace = str.IndexOf(' ');

            return index == 0 ? HttpUtility.HtmlDecode(str.Substring(0, indexOfFirstSpace)) : str.Substring(indexOfFirstSpace + 1, str.Length - indexOfFirstSpace - 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
