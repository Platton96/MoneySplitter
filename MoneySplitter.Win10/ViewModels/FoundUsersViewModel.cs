using Caliburn.Micro;
using Windows.UI.Xaml;
using MoneySplitter.Win10.Common;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class FoundUsersViewModel : Screen
    {

        public SearchEngine SearchEngine { get; set; }

        public FoundUsersViewModel(SearchEngine searchEngine)
        {
            SearchEngine = searchEngine;
        }
        
        public async Task PerformSearchUsersAsync(string query)
        {
           await SearchEngine.PerformUsersSearchAsync(query);
        }
    }
}
