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
    }
}
