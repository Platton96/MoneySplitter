using MoneySplitter.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using System.Linq;
using System.Collections.ObjectModel;

namespace MoneySplitter.Win10.Common
{
    public class SearchEngine : PropertyChangedBase
    {
        private readonly DispatcherTimer _timer;

        private readonly ISearchApiService _searchApiService;
        private bool _isSearchInProgress;
        private string _previousQuery = string.Empty;
        private string _query;
        private const int INTERVAL_TIME = 1;

        private TimeSpan TIMER_INTERVAL = TimeSpan.FromSeconds(INTERVAL_TIME);

        private ObservableCollection<UserModel> _results;

        public ObservableCollection<UserModel> Results
        {
            get => _results;
            set
            {
                _results = value;
                NotifyOfPropertyChange(nameof(Results));
            }
        }

        public SearchEngine(ISearchApiService searchApiService )
        {
            _timer = new DispatcherTimer
            {
                Interval = TIMER_INTERVAL
            };

            _timer.Tick += OnTimerTick;

            _searchApiService = searchApiService;
        }

        private async void OnTimerTick(object sender, object e)
        {
            await PerformUsersSearchAsync();
        }

        public void Activate()
        {
            _timer.Start();
        }

        public void ChangedQeury(string query)
        {
            _query = query;
            _timer.Stop();
            _timer.Start();
        }
        public async Task PerformUsersSearchAsync()
        {
            if (_isSearchInProgress || _query == _previousQuery)
            {
                return;
            }

            if (string.IsNullOrEmpty(_query))
            {
                Results?.Clear();
                _previousQuery = _query;
                return;
            }

            _isSearchInProgress = true;

            var responce = await _searchApiService.SearchUsersAsync(_query);

            _previousQuery = _query;
            Results = new ObservableCollection<UserModel>(responce.ToList());

            _isSearchInProgress = false;
        }

        public void Deactivate()
        {
            _timer.Stop();
        }
    }
}
