using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class RegisterView : Page
    {
        public RegisterViewModel ViewModel { get; set; }

        public RegisterView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as RegisterViewModel; };
        }

        private async void OnRegistrButtonClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.Register();
        }
    }
}
