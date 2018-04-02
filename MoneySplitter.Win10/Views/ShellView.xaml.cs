using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml.Controls;

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

        //private void ShellFrame_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    ViewModel.InitializeShellNavigationService(ShellFrame);
        //}
    }
}
