using System;

namespace MoneySplitter.Infrastructure
{
    public interface INavigationManager
    {
        void NavigateToShellViewModel();
        void NavigateToRegisterViewModel();
        void InitializeShellNavigationService(object navigationService);
        void NavigateToMainPage();
        void NavigateToFriends();
        void NavigateToShellViewModel(Type viewModelType);
        void NavigateToFoundUsersViewModel();
        void GoBack();

        event EventHandler OnShellNavigationManagerNavigated;
    }
}
