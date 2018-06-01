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

        private async void OnBrowseImageButtonClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.BrowseTransactionImageAsync();
        }

        private async void AddTransactionAsync(object sender, RoutedEventArgs e)
        {
            await ViewModel.AddTransactionAsync();
        }

        private void OnAddFriendClick(object sender, ItemClickEventArgs e)
        {
            var selectedFriend = e.ClickedItem as UserModel;
            ViewModel.AddFriendToCollabarators(selectedFriend.Id);
        }

        private void OnRemoveFriendClick(object sender, ItemClickEventArgs e)
        {
            var selectedFriend = e.ClickedItem as UserModel;
            ViewModel.RemoveFriendFromCollabarators(selectedFriend.Id);
        }
    }
}
