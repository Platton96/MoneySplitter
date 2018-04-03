using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class RegistrView : Page
    {
        public RegistrViewModel ViewModel { get; set; }

        public RegistrView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as RegistrViewModel; };
        }

        private async void OnRegistrButtonClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.Registred();
        }
    }
}
