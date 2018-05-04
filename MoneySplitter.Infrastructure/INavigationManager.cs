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
        void NavigateToShellViewModel(Type viewModelType);
        void NavigateToSearchUsersViewModel();
        void NavigateToAddTransactionViewModel();
        void GoBack();

        event EventHandler<Type> OnShellNavigationManagerNavigated;
    }
}
