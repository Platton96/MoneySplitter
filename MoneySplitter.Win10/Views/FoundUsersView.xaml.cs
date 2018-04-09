using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class FoundUsersView : Page
    {
        public FoundUsersViewModel ViewModel { get; set; }

        public FoundUsersView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as FoundUsersViewModel; };
        }

        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchBox = sender as TextBox;
            ViewModel.ChangedQuery(searchBox.Text);
        }

        private async void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            var selectUser = ((FrameworkElement)sender).DataContext as UserModel;
            await ViewModel.AddFriendAsync(selectUser.Id);
        }
    }
}
