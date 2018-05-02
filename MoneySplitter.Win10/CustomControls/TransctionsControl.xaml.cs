using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
