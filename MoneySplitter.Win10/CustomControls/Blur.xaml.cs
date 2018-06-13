using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MoneySplitter.Win10.CustomControls
{
	public sealed partial class Blur
	{
		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
			"Value",
			typeof(double),
			typeof(Blur),
			new PropertyMetadata(default(double)));

		public static readonly DependencyProperty BlurBackgroundProperty = DependencyProperty.Register(
			"BlurBackground",
			typeof(SolidColorBrush),
			typeof(Blur),
			new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

		public double Value
		{
			get => (double)GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		public SolidColorBrush BlurBackground
		{
			get => (SolidColorBrush)GetValue(BlurBackgroundProperty);
			set => SetValue(BlurBackgroundProperty, value);
		}

		public Blur()
		{
			InitializeComponent();
		}
	}
}
