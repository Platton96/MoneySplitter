using System;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class PhoneNumberConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            return String.Format("{0:+### (##) ###-##-##}", (long)value);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
