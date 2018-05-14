using MoneySplitter.Models;
using MoneySplitter.Models.App;
using MoneySplitter.Win10.CustomControls.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class ArrowsControl : UserControl
    {
        private IDictionary<CollabaratorStatus, ArrowModel> _arrows;

        private void InitializeArrows()
        {
            _arrows = new Dictionary<CollabaratorStatus, ArrowModel>()
            {
                {
                    CollabaratorStatus.ONE_LEND,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.DOWN),
                        Color = RedBrush
                    }
                 },

                 {
                    CollabaratorStatus.MANY_LEND,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.DOWN),
                        Color = RedBrush
                    }
                 },

                 {
                    CollabaratorStatus.ONE_DEBT,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.UP),
                        Color = GreenBrush
                    }
                 },

                 {
                    CollabaratorStatus.MANY_DEBT,
                    new ArrowModel
                    {
                        Glyph = HttpUtility.HtmlDecode(Defines.Arrow.Glyph.UP),
                        Color = GreenBrush
                    }
                 },

            };
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
          "Value",
          typeof(CollabaratorStatus),
          typeof(ArrowsControl),
          new PropertyMetadata(default(CollabaratorStatus), new PropertyChangedCallback(OnValueChanged)));

        public CollabaratorStatus Value
        {
            get => (CollabaratorStatus)GetValue(ValueProperty);
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
            if (Value == CollabaratorStatus.ONE_DEBT || Value == CollabaratorStatus.ONE_LEND)
            {
                SecondArrowIcon.Visibility = Visibility.Collapsed;
            }


            var a = RedBrush;
            FirstArrowIcon.Glyph = _arrows[Value].Glyph;
            FirstArrowIcon.Foreground = _arrows[Value].Color;

            SecondArrowIcon.Glyph = _arrows[Value].Glyph;
            SecondArrowIcon.Foreground = _arrows[Value].Color;
        }
    }
}
