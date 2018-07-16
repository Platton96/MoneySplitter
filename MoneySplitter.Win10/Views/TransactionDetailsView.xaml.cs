using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
	public sealed partial class TransactionDetailsView : Page
	{
		public TransactionDetailsViewModel ViewModel { get; set; }

		public TransactionDetailsView()
		{
			InitializeComponent();

			DataContextChanged += (s, e) =>
			{
				ViewModel = DataContext as TransactionDetailsViewModel;
			};
		}

        private async void OnGiveButtonClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.MoveUserToInProgressAsync();
        }

        private async void OnRemindButtonClick(object sender, RoutedEventArgs e)
        {
            //code for remind
        }
    }
}
