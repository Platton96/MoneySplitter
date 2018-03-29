using MoneySplitter.Models;

namespace MoneySplitter.Infrastructure
{
    public interface INavigateManager
    {
        void NavigateToShellView(UserModel userModel);
    }
}
