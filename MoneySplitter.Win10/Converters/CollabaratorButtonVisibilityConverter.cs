using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
    public class CollabaratorButtonVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            var collabaratorStatus = (CollaboratorStatus)value;

            if (collabaratorStatus == CollaboratorStatus.MANY_LEND || collabaratorStatus == CollaboratorStatus.MANY_DEBT)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
