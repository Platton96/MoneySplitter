using Caliburn.Micro;
using MoneySplitter.Services;
using MoneySplitter.Services.Api;
using MoneySplitter.Infrastructure;
using MoneySplitter.Win10.ViewModels;
using MoneySplitter.Win10.Common;
using MoneySplitter.Services.Inerfaces;
using MoneySplitter.Managers;

namespace MoneySplitter.Win10.Dependencies
{
    public class WinAppDependenciesModule
    {
        private WinRTContainer _container;

        public WinAppDependenciesModule(WinRTContainer container)
        {
            _container = container;
        }

        public void InitializeViewModel()
        {
            _container.PerRequest<LoginViewModel>();
            _container.PerRequest<RegisterViewModel>();

            _container.PerRequest<ShellViewModel>();

            _container.PerRequest<HomeViewModel>();
            _container.PerRequest<FriendsViewModel>();
            _container.PerRequest<SearchUsersViewModel>();
            _container.PerRequest<TransactionsViewModel>();
            _container.PerRequest<AddTransactionViewModel>();
            _container.PerRequest<IncomingAndOutcomingViewModel>();
            _container.PerRequest<FriendDetailsViewModel>();
        }

        public void InitializeServices()
        {
            _container.Singleton<INavigationManager, NavigationManager>();

            _container.Singleton<IApiUrlBuilder, ApiUrlBuilder>();
            _container.Singleton<IQueryApiService, QueryApiService>();

            _container.Singleton<ISessionApiService, SessionApiService>();
            _container.Singleton<ISearchApiService, SearchApiService>();
            _container.Singleton<IFriendsApiService, FriendsApiService>();
            _container.Singleton<ITransactionsApiService, TransactionsApiService>();
            _container.Singleton<IMembershipService, MembershipService>();
            _container.Singleton<IFriendsManager, FriendsManager>();
            _container.Singleton<ITransactionsManager, TransactionsManager>();
            _container.Singleton<IMapper, Mapper>();
            _container.Singleton<IExecutor, Executor>();

            _container.Singleton<IFilePickerService, FilePickerService>();
            _container.Singleton<CollaboratorModelFactory>();
            _container.Singleton<FriendTransactionModelFactory>();
            _container.Singleton<TransactionEventModelFactory>();
            _container.Singleton<SearchEngine>();
        }
    }
}
