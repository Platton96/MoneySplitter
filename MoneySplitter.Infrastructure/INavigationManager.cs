using System;

namespace MoneySplitter.Infrastructure
{
    public interface INavigationManager
    {
        void NavigateToShellViewModel();
        void NavigateToRegisterViewModel();
        void InitializeShellNavigationService(object navigationService);
        void NavigateToHome();
        void NavigateToFriends();
        void NavigateToShellViewModel(Type viewModelType);
        void NavigateToFoundUsersViewModel();
        void GoBack();

        event EventHandler<Type> OnShellNavigationManagerNavigated;
    }
}
