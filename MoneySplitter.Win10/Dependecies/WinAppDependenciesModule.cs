﻿using Caliburn.Micro;
using MoneySplitter.Services;
using MoneySplitter.Services.Api;
using MoneySplitter.Infrastructure;
using MoneySplitter.Win10.ViewModels;
using MoneySplitter.Win10.Common;
using MoneySplitter.Services.API;
using MoneySplitter.Services.Inerfaces;

namespace MoneySplitter.Win10.Dependencies
{
    public  class WinAppDependenciesModule
    {
        private WinRTContainer _container;

        public WinAppDependenciesModule(WinRTContainer container)
        {
            _container = container;
        }

        public void InitializeViewModel()
        {
            _container.PerRequest<LoginViewModel>();
            _container.PerRequest<ShellViewModel>();
            _container.PerRequest<RegisterViewModel>();
            _container.PerRequest<HelloWorldViewModel>();
            _container.PerRequest<FriendsViewModel>();
            _container.PerRequest<FoundUsersViewModel>();
        }

        public void InitializeServices()
        {
            _container.Singleton<INavigationManager, NavigationManager>();

            _container.Singleton<IApiUrlBuilder, ApiUrlBuilder>();

            _container.Singleton<ISessionApiService, SessionApiService>();
            _container.Singleton<IMembershipService, MembershipService>();
            _container.Singleton<ISearchApiService, SearchApiService>();

            _container.Singleton<IQueryApiService, QueryApiService>();

            _container.Singleton<IMapper, Mapper>();

            _container.Singleton<SearchEngine>();
        }

    }
}
