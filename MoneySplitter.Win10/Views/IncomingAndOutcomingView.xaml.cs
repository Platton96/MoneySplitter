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
using MoneySplitter.Win10.ViewModels;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class IncomingAndOutcomingView : Page
    {
        IncomingAndOutcomingViewModel ViewModel { get; set; }
        public IncomingAndOutcomingView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as IncomingAndOutcomingViewModel; };
        }
    }
}
