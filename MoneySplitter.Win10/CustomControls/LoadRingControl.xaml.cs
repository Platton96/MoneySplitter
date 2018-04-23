using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class LoadRingControl : UserControl
    {
        public LoadRingControl()
        {
            InitializeComponent();
        }
        public bool IsActiveRing
        {
            get { return (bool)GetValue(IsActiveRingPropery); }
            set { SetValue(IsActiveRingPropery, value); }
        }

        public static readonly DependencyProperty IsActiveRingPropery = DependencyProperty.Register(
            "IsActiveRing",
            typeof(bool),
            typeof(LoadRingControl),
            null);
    }
}
