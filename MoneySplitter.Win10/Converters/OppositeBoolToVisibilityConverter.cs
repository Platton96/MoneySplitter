using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
	public class OppositeBoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var isTrue = (bool)value;
			return !isTrue ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
