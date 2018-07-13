using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Win10.ViewModels;
using MoneySplitter.Win10.Views;
using System;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MoneySplitter.Win10.Common
{
	public class NavigationManager : INavigationManager
	{
		#region Fields and constructor
		private readonly INavigationService _windowNavigationService;
		private INavigationService _shellNavigationService;

		public event EventHandler<Type> OnShellNavigationManagerNavigated;

		public NavigationManager(INavigationService navigationService)
		{
			_windowNavigationService = navigationService;
		}
		#endregion

		public void NavigateToShellViewModel()
		{
			_windowNavigationService.NavigateToViewModel<ShellViewModel>();
		}

		public void InitializeShellNavigationService(object navigationService)
		{
			_shellNavigationService = (INavigationService)navigationService;
			_shellNavigationService.Navigated += OnShellNavigationServiceNavigated;
		}

		public void NavigateToRegisterViewModel()
		{
			_windowNavigationService.NavigateToViewModel<RegisterViewModel>();
		}
        public void NavigateToLoginViewModel()
        {
            _windowNavigationService.NavigateToViewModel<LoginViewModel>();
        }

        public void NavigateToHomeViewModel()
		{
			_shellNavigationService.NavigateToViewModel<HomeViewModel>();
		}

		public void NavigateToFriendsViewModel()
		{
			_shellNavigationService.NavigateToViewModel<FriendsViewModel>();
		}

		public void NavigateToFriendDetails(UserModel userModel)
		{
			_shellNavigationService.NavigateToViewModel<FriendDetailsViewModel>(userModel);
		}

		public void NavigateToAddTransactionViewModel()
		{
			_shellNavigationService.NavigateToViewModel<AddTransactionViewModel>();
		}

		public void NavigateToTransactionDetailsViewModel(TransactionEventModel transaction)
		{
			_shellNavigationService.NavigateToViewModel<TransactionDetailsViewModel>(transaction);
		}

		public void NavigateToTransactionsViewModel()
		{
			_shellNavigationService.NavigateToViewModel<TransactionsViewModel>();
		}

		public void NavigateToSearchUsersViewModel()
		{
			_shellNavigationService.NavigateToViewModel<SearchUsersViewModel>();
		}

		public void NavigateToShellViewModel(Type viewModelType)
		{
			_shellNavigationService.NavigateToViewModel(viewModelType);
		}

		public void GoBack()
		{
			if (_shellNavigationService.CanGoBack)
			{
				_shellNavigationService.GoBack();
			}
		}

		private void SetBackButtonVisibility(bool value)
		{
			SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = value ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
		}

		private void OnShellNavigationServiceNavigated(object sender, NavigationEventArgs e)
		{
			var sameViewModel = _shellNavigationService.BackStack.FirstOrDefault(w => w.SourcePageType == e.SourcePageType);
			if (sameViewModel != null)
			{
				_shellNavigationService.BackStack.Remove(sameViewModel);
			}

			SetBackButtonVisibility(_shellNavigationService.CanGoBack && CheckLoginView(sender as Frame));
			OnShellNavigationManagerNavigated?.Invoke(this, (e.Content as Page).DataContext.GetType());
		}
        private bool CheckLoginView(Frame frame)
        {
            return frame.Content.GetType().Name != Defines.LOGIN_VIEW;
        }
	}
}
