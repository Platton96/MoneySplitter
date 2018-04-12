using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class ShellView : Page
    {
        public ShellViewModel ViewModel { get; set; }

        public ShellView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as ShellViewModel; };
        }

        private void OnMenuItemClick(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var selectedMenuItem = args.InvokedItem as MenuItemModel;
            ViewModel.NavigateToClikedItemMenu(selectedMenuItem.Text);
        }

        private void OnShellFrameLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.InitializeShellNavigationService(ContentFrame);
        }
    }
}
