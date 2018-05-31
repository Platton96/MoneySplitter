using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class TransactionsView : Page
    {
        public TransactionsViewModel ViewModel { get; set; }

        public TransactionsView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as TransactionsViewModel; };
        }

        private void OnAddTransactionButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.NavigateToAddTransaction();
        }
        private void OnRemindCollaboratorButtonClick(object sender, TransactionEventModel e)
        {
            //code for remind
        }

        private async void OnGiveCollaboratorButtonClick(object sender, TransactionEventModel e)
        {
            await ViewModel.MoveUserToInProgressAsync(e.TransactionId);
        }

  

        private void OnSelectSortParameter(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
