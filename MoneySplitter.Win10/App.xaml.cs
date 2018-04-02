using Caliburn.Micro;
using MoneySplitter.Win10.Views;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using MoneySplitter.Win10.Dependencies;

namespace MoneySplitter.Win10
{

    public sealed partial class App
    {
        private WinRTContainer _container;
        private WinAppDependenciesModule _winAppDependenciesModule;

        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _winAppDependenciesModule = new WinAppDependenciesModule(_container);

            _winAppDependenciesModule.InitializeViewModel();
            _winAppDependenciesModule.InitializeServices();
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                return;
            }

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
