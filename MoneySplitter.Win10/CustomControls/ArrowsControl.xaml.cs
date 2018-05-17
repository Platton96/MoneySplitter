using MoneySplitter.Models;
using MoneySplitter.Win10.CustomControls.Models;
using System.Collections.Generic;
using System.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class ArrowsControl : UserControl
    {
        private IDictionary<CollaboratorStatus, ArrowModel> _arrows;

        private void InitializeArrows()
        {
            _arrows = new Dictionary<CollaboratorStatus, ArrowModel>()
            {
                {
                    CollaboratorStatus.ONE_LEND,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.UP),
                        Color = RedBrush
                    }
                 },

                 {
                    CollaboratorStatus.MANY_LEND,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.UP),
                        Color = RedBrush
                    }
                 },

                 {
                    CollaboratorStatus.ONE_DEBT,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.DOWN),
                        Color = GreenBrush
                    }
                 },

                 {
                    CollaboratorStatus.MANY_DEBT,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.DOWN),
                        Color = GreenBrush
                    }
                 },

            };
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
          "Value",
          typeof(CollaboratorStatus),
          typeof(ArrowsControl),
          new PropertyMetadata(default(CollaboratorStatus), new PropertyChangedCallback(OnValueChanged)));

        public CollaboratorStatus Value
        {
            get => (CollaboratorStatus)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public ArrowsControl()
        {
            InitializeComponent();
            InitializeArrows();
        }

        public static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            var control = (ArrowsControl)sender;
            control.UpdateArrowsStatus();
        }

        public void UpdateArrowsStatus()
        {
            if (Value == CollaboratorStatus.ONE_DEBT || Value == CollaboratorStatus.ONE_LEND)
            {
                SecondArrowIcon.Visibility = Visibility.Collapsed;
            }

            FirstArrowIcon.Glyph = _arrows[Value].Glyph;
            FirstArrowIcon.Foreground = _arrows[Value].Color;

            SecondArrowIcon.Glyph = _arrows[Value].Glyph;
            SecondArrowIcon.Foreground = _arrows[Value].Color;
        }
    }
}
