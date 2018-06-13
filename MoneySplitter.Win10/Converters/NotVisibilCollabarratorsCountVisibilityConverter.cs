using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class NotVisibilCollabarratorsCountVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            if ((int)value < 2)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
