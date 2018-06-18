using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

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
            var localizationService = Dependecies.Dependecies.LocalizationService;
            localizationService.InitializeStrings(Defines.Localization.RESOURCE_RU_FILE_PATCH);

            var elementContent = localizationService.GetValue(e.NewValue.ToString());

            if (control is TextBlock textBlock)
            {
                textBlock.Text = elementContent;
                return;
            }

            if (control is Button button)
            {
                button.Content = elementContent;
                return;
            }

            if (control is TextBox textBox)
            {
                textBox.PlaceholderText = elementContent;
                return;
            }

            if (control is PasswordBox passwordBox)
            {
                passwordBox.PlaceholderText = elementContent;
                return;
            }

            if (dependencyObject is Run run)
            {
                run.Text = elementContent;
            }

        }
    }
}
