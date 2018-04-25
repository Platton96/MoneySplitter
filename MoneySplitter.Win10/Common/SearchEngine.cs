using MoneySplitter.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Caliburn.Micro;
using MoneySplitter.Infrastructure;
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

        private TimeSpan TIMER_INTERVAL = TimeSpan.FromSeconds(1);

        private ObservableCollection<UserModel> _results;

        public ObservableCollection<UserModel> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                NotifyOfPropertyChange(nameof(Results));
            }
        }

        public bool IsSearchInProgress
        { 
            get { return _isSearchInProgress; }
            set
            {
                _isSearchInProgress = value;
                NotifyOfPropertyChange(nameof(IsSearchInProgress));
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

            IsSearchInProgress = true;

            var responce = await _searchApiService.SearchUsersAsync(_query);

            _previousQuery = _query;
            Results = new ObservableCollection<UserModel>(responce);

            IsSearchInProgress = false;
        }

        public void Deactivate()
        {
            _timer.Stop();

            Results?.Clear();
        }
    }
}
