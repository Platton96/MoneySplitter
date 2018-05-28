using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class DateCoverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            var date = (DateTime?)value;

            if(date.Value.Date==DateTime.Now.Date)
            {
                return String.Format("{0}: {1}", "Today", date.Value.ToLongTimeString());
            }

            if (date.Value.Date==DateTime.Now.AddDays(1).Date)
            {
                return String.Format("{0}: {1}", "Tommorow", date.Value.ToLongTimeString());
            }

            return date.Value.ToLongDateString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
