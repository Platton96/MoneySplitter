using System;

namespace MoneySplitter.Infrastructure
{
    public interface INavigationManager
    {
        void NavigateToShellView();
        void NavigateToRegistrViewModel();
        void InitializeShellNavigationService(object navigationService);
        void NavigateToShellViewModel();
        void NavigateToFriends();
        void NavigateToShellViewModel(Type viewModelType);
        void NavigateToFoundUsersViewModel(object parametr);

    }
}
