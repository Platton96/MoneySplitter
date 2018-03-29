﻿using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Win10.Common;
using MoneySplitter.Win10.ViewModels;
using MoneySplitter.Win10.Views;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>

    public sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();

            _container.RegisterWinRTServices();

            _container.PerRequest<LoginViewModel>();
             _container.Singleton<INavigationManager, NavigationManager>();
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootView<LoginView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
