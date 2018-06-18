using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Extensions
{
    public static class XamlElementExtensions
    {
        public static readonly DependencyProperty ResourceProperty =
        DependencyProperty.RegisterAttached("Resource", typeof(string), typeof(XamlElementExtensions), new PropertyMetadata(string.Empty, OnResourceChanged));
        public static string GetResource(DependencyObject obj) { return (string)obj.GetValue(ResourceProperty); }
        public static void SetResource(DependencyObject obj, string value) { obj.SetValue(ResourceProperty, value); }

        private static void OnResourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var control = (FrameworkElement)dependencyObject;

            if (control is TextBlock textBlock)
            {
                // TODO get string from service
                textBlock.Text = e.NewValue.ToString();
            }

            if (control is Button button)
            {
                button.Content = e.NewValue.ToString();
            }
        }
    }
}
