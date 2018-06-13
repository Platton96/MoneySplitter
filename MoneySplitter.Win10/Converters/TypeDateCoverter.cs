using MoneySplitter.Models;
using System;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class TypeDateCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            var typeDate = (DateType)value;

            if(typeDate==DateType.DEADLINE_DATE)
            {
                return "Deadline: ";
            }
            return "Event date: ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
