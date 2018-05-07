using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class AddTransactionView : Page
    {
        AddTransactionViewModel ViewModel { get; set; }

        public AddTransactionView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as AddTransactionViewModel; };
        }

        private void OnAddFriendButtonClick(object sender, UserModel e)
        {
            ViewModel.AddFriendToCollabarators(e.Id);
        }

        private void OnRemoveFriendButtonClick(object sender, UserModel e)
        {
            ViewModel.RemoveFriendFromCollabarators(e.Id);
        }

        private async void OnBrowseImageButtonClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.BrowseTransactionImageAsync();
        }

        private async void AddTransactionAsync(object sender, RoutedEventArgs e)
        {
            await ViewModel.AddTransactionAsync();
        }
    }
}
