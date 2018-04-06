﻿using MoneySplitter.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class ShellView : Page
    {
        public ShellViewModel ViewModel { get; set; }

        public ShellView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as ShellViewModel; };
        }

        private void OnMenuItemClick(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ViewModel.NavigateToClikedItemMenu((string)args.InvokedItem);
        }

        private void OnShellFrameLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.InitializeShellNavigationService(ContentFrame);
        }

        private void OnSearchBoxTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ViewModel.NovigaateToFoundUsers();
        }
    }
}