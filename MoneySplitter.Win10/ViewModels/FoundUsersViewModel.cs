using Caliburn.Micro;
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

        public void ChangedQuery(string query)
        {
            SearchEngine.ChangedQeury(query);
        }

        protected override void OnActivate()
        {
            SearchEngine.Activate();
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            SearchEngine.Deactivate();
        }
    }
}
