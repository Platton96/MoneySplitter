using MoneySplitter.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class TransctionsControl : UserControl
    {
        public TransactionModel ViewModel
        {
            get { return (TransactionModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(TransactionModel),
            typeof(TransctionsControl),
            null);
        public TransctionsControl()
        {
            InitializeComponent();
        }
    }
}
