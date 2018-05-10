using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class FriendsView : Page
    {
        public FriendsViewModel ViewModel { get; set; }

        public FriendsView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as FriendsViewModel; };
        }

        private async void OnRemoveItemClick(object sender, UserModel e)
        {
            await ViewModel.RemoveFriendAsync(e.Id);
        }
    }
}
