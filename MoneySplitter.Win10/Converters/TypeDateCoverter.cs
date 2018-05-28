using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class TypeDateCoverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            var typeDate = (TypeDate)value;

            if(typeDate==TypeDate.DEADLINE_DATE)
            {
                return "Deadline date: ";
            }
            return "Event date: ";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
