using System;

namespace MoneySplitter.Infrastructure
{
    public interface INavigationManager
    {
        void NavigateToShellView();
        void NavigateToRegistrViewModel();
        void InitializeShellNavigationService(object navigationService);
        void NavigateToShellViewModel();
        void NavigateToFriendsViewModelFrame();
        void NavigateToShellViewModel(Type viewModelType);
    }
}
