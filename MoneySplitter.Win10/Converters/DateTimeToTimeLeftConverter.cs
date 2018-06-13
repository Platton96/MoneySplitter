using System;
using Windows.UI.Xaml.Data;

namespace MoneySplitter.Win10.Converters
{
	public class DateTimeToTimeLeftConverter : IValueConverter
	{
		//TODO To get these values from resources
		private const string HOURS = "hours";
		private const string MINUTES = "minutes";
		private const string DAYS = "days";
		private const string ONGOING_TEMPLATE = "{0} left";
		private const string OVERDUED_TEMPLATE = "{0} overdued";

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
			{
				return null;
			}

			var date = (DateTime)value;

			var difference = date - DateTime.Now;
			if (difference < TimeSpan.Zero)
			{
				difference = -difference;
			}

			var result = string.Empty;

			if (difference.Days >= 1)
			{
				result += $"{difference.Days} {DAYS} ";
			}

			if (difference.Hours >= 1)
			{
				result += $"{difference.Hours} {HOURS} ";
			}

			if (difference.Days < 1)
			{
				result += $"{difference.Minutes} {MINUTES} ";
			}

			return string.Format(date - DateTime.Now > TimeSpan.Zero ? ONGOING_TEMPLATE : OVERDUED_TEMPLATE, result);

		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
