using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
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

namespace MoneySplitter.Win10.Views
{
    public sealed partial class AddTransactionView : Page
    {
        AddTransactionViewModel ViewModel { get; set; }

        public AddTransactionView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as AddTransactionViewModel; };
        }

        private void OnAddFriendButtonClick(object sender, UserModel e)
        {
            ViewModel.AddFriendToCollabarators(e.Id);
        }

        private void OnRemoveFriendButtonClick(object sender, UserModel e)
        {
            ViewModel.RemoveFriendFromCollabarators(e.Id);
        }
    }
}
