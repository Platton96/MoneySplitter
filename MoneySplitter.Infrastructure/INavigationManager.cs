using System;

namespace MoneySplitter.Infrastructure
{
    public interface INavigationManager
    {
        void NavigateToShellView();
        void NavigateToRegisterViewModel();
        void InitializeShellNavigationService(object navigationService);
        void NavigateToShellViewModel();
        void NavigateToFriends();
        void NavigateToShellViewModel(Type viewModelType);
        void NavigateToFoundUsersViewModel();
    }
}
