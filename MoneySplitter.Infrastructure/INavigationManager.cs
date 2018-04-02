using Caliburn.Micro;

namespace MoneySplitter.Infrastructure
{
    public interface INavigationManager
    {
        void NavigateToShellView();
        void NavigateToRegistrViewModel();
        void InitializeShellNavigationService(object navigationService);
        void NavigateShellViewModel();
    }
}
