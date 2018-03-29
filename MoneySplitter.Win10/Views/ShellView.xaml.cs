using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MoneySplitter.Win10.Views
{

    public sealed partial class ShellView : Page
    {
        public ShellViewModel ViewModel { get; set; }

        public ShellView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as ShellViewModel; };
        }
    }
}
