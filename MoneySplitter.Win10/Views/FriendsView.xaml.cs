using MoneySplitter.Win10.ViewModels;
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
    }
}
