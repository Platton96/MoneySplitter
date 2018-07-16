using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class FriendDetailsView : Page
    {
        FriendDetailsViewModel ViewModel { get; set; }
        public FriendDetailsView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as FriendDetailsViewModel; };
        }

        private void OnTransactionItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToTransactionDetails(e.ClickedItem as TransactionEventModel);
        }

        private void OnRemindButtonClick(object sender, TransactionEventModel e)
        {
            //code for remind
        }

        private void OnSmallRingerButtonClick(object sender, TransactionEventModel e)
        {
            //code for remind
        }

        private async void OnApproveButtonClick(object sender, TransactionEventModel e)
        {
            await ViewModel.MoveUserToInFinishedAsync(e.TransactionId);
        }

        private async void OnGiveButtonClick(object sender, TransactionEventModel e)
        {
            await ViewModel.MoveUserToInProgressAsync(e.TransactionId);
        }

        private async void OnApproveAllButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.CloseAllTransactionAsync();
        }
    }
}
