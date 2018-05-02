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
        #region Fields
        private readonly DispatcherTimer _timer;

        private readonly ISearchApiService _searchApiService;
        private bool _isSearchInProgress;
        private string _previousQuery = string.Empty;
        private string _query;

        private string _statusMessage;
        private bool _isStatusMessageVisible=true;

        private TimeSpan TIMER_INTERVAL = TimeSpan.FromSeconds(1);
        #endregion

        #region Properties
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

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                NotifyOfPropertyChange(nameof(StatusMessage));
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

        public bool IsStatusMessageVisible
        {
            get { return _isStatusMessageVisible; }
            set
            {
                _isStatusMessageVisible = value;
                NotifyOfPropertyChange(nameof(IsStatusMessageVisible));
            }
        }
        #endregion

        #region Constructor
        public SearchEngine(ISearchApiService searchApiService )
        {
            _timer = new DispatcherTimer
            {
                Interval = TIMER_INTERVAL
            };

            _timer.Tick += OnTimerTick;

            _searchApiService = searchApiService;
        }
        #endregion

        #region Public methods
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
                StatusMessage = Defines.Search.TEXTBOX_EMPTY;
                IsStatusMessageVisible = true;
                _previousQuery = _query;
                return;
            }

            IsSearchInProgress = true;

            var executionResult = await _searchApiService.SearchUsersAsync(_query);

            _previousQuery = _query;

            if (!executionResult.IsSuccess)
            {
                Results?.Clear();
                StatusMessage = Defines.ErrorDetails.PROBLEM_SERVER;
                IsStatusMessageVisible = true;
                return;
            }

            Results = new ObservableCollection<UserModel>(executionResult.Result);
            if(Results.Count==0)
            {
                StatusMessage = Defines.Search.NOT_RESULTS;
                IsStatusMessageVisible = true;
            }
            else
            {
                IsStatusMessageVisible = false;
            }
            IsSearchInProgress = false;
        }

        public void Deactivate()
        {
            _timer.Stop();

            Results?.Clear();
        }
        #endregion

        #region Private methods
        private async void OnTimerTick(object sender, object e)
        {
            await PerformUsersSearchAsync();
        }
        #endregion
    }
}
