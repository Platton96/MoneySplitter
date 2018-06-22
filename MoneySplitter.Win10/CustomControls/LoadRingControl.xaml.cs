using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class LoadRingControl : UserControl
    {
        public bool IsActiveRing
        {
            get => (bool)GetValue(IsActiveRingProperty); 
            set { SetValue(IsActiveRingProperty, value); }
        }

        public static readonly DependencyProperty IsActiveRingProperty = DependencyProperty.Register(
            "IsActiveRing",
            typeof(bool),
            typeof(LoadRingControl),
            null);

        public LoadRingControl()
        {
            InitializeComponent();
        }
    }
}
