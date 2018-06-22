using MoneySplitter.Models.App;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class ErrorDetailsControl : UserControl
    {
        public bool IsErrorVisable
        {
            get => (bool)GetValue(IsErrorVisableProperty); 
            set { SetValue(IsErrorVisableProperty, value); }
        }

        public ErrorDetailsModel ErrorDetails
        {
            get => (ErrorDetailsModel)GetValue(ErrorDetailsProperty); 
            set { SetValue(ErrorDetailsProperty, value); }
        }

        public static readonly DependencyProperty IsErrorVisableProperty = DependencyProperty.Register(
            "IsErrorVisable",
            typeof(bool),
            typeof(ErrorDetailsControl),
            null);

        public static readonly DependencyProperty ErrorDetailsProperty = DependencyProperty.Register(
            "ErrorDetails",
            typeof(ErrorDetailsModel),
            typeof(ErrorDetailsControl),
            null);

        public ErrorDetailsControl()
        {
            InitializeComponent();
        }
    }
}
