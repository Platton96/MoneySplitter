using System;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class BankCardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            return String.Format("{0:####-####-####-####}", (long)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
