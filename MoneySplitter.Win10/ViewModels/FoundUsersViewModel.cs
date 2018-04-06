using Caliburn.Micro;
using Windows.UI.Xaml;
using MoneySplitter.Win10.Common;

namespace MoneySplitter.Win10.ViewModels
{
    public class FoundUsersViewModel : Screen
    {
        public SearchEngine SearchEngine { get; set; }
        

        public FoundUsersViewModel(SearchEngine searchEngine)
        {
            SearchEngine = searchEngine;
        }

        protected override void OnActivate()
        {
            SearchEngine.Activate();
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            SearchEngine.Deactivate();
            base.OnDeactivate(close);
        }
    }
}
