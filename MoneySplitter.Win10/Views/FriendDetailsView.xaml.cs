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
    }
}
