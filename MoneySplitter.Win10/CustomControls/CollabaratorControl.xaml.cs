using MoneySplitter.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class CollabaratorControl : UserControl
    {
        public event EventHandler<CollabaratorModel> OnItemClick;

        public CollabaratorModel ViewModel
        {
            get { return (CollabaratorModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public string ButtonContent
        {
            get { return (string)GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }

        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }
        public bool IsButtonVisible
        {
            get { return (bool)GetValue(IsButtonVisibleProperty); }
            set { SetValue(IsButtonVisibleProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(CollabaratorModel),
            typeof(CollabaratorControl),
            null);

        public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register(
            "ButtonContent",
            typeof(string),
            typeof(CollabaratorControl),
            null);

        public static readonly DependencyProperty IconGlyphProperty = DependencyProperty.Register(
            "IconGlyph",
            typeof(string),
            typeof(CollabaratorControl),
            null);

        public static readonly DependencyProperty IsButtonVisibleProperty = DependencyProperty.Register(
            "IsButtonVisible",
            typeof(bool),
            typeof(CollabaratorControl),
            null);

        public CollabaratorControl()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            OnItemClick?.Invoke(this, ViewModel);
        }
    }
}
