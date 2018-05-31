using MoneySplitter.Models;
using System;

namespace MoneySplitter.Infrastructure
{
	public interface INavigationManager
	{
		void NavigateToShellViewModel();
		void NavigateToRegisterViewModel();
		void InitializeShellNavigationService(object navigationService);
		void NavigateToHomeViewModel();
		void NavigateToFriendsViewModel();
		void NavigateToFriendDetails(UserModel userModel);
		void NavigateToShellViewModel(Type viewModelType);
		void NavigateToSearchUsersViewModel();
		void NavigateToAddTransactionViewModel();
		void NavigateToTransactionsViewModel();
		void NavigateToTransactionDetailsViewModel(TransactionEventModel transaction);
		void GoBack();

		event EventHandler<Type> OnShellNavigationManagerNavigated;
	}
}
