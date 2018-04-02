using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class LoginView : Page
    {
        public LoginViewModel ViewModel { get; set; }
        public LoginView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as LoginViewModel; };
        }

        private async void OnLoginClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.SignInAsync();
        }

        private void OnRegistredClick(object sender, RoutedEventArgs e)
        {
            ViewModel.GoToRegistretion();
        }
    }
}
