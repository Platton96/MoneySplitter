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
        private readonly ILocalizationService _localizationService;

        private bool _isSearchInProgress;
        private string _previousQuery;
        private string _query;

        private string _statusMessage;
        private bool _isStatusMessageVisible=true;

        private TimeSpan TIMER_INTERVAL = TimeSpan.FromSeconds(1);
        #endregion

        #region Properties
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

        public string StatusMessage
        {
            get => _statusMessage; 
            set
            {
                _statusMessage = value;
                NotifyOfPropertyChange(nameof(StatusMessage));
            }
        }

        public bool IsSearchInProgress
        { 
            get => _isSearchInProgress; 
            set
            {
                _isSearchInProgress = value;
                NotifyOfPropertyChange(nameof(IsSearchInProgress));
            }
        }

        public bool IsStatusMessageVisible
        {
            get => _isStatusMessageVisible; 
            set
            {
                _isStatusMessageVisible = value;
                NotifyOfPropertyChange(nameof(IsStatusMessageVisible));
            }
        }
        #endregion

        #region Constructor
        public SearchEngine(ISearchApiService searchApiService, ILocalizationService localizationService)
        {
            _timer = new DispatcherTimer
            {
                Interval = TIMER_INTERVAL
            };

            _timer.Tick += OnTimerTick;

            _searchApiService = searchApiService;

            _localizationService = localizationService;
        }
        #endregion

        #region Public methods
        public void Activate()
        {
            _previousQuery = string.Empty;
            _query = string.Empty;
            IsStatusMessageVisible = true;
            StatusMessage = _localizationService.GetValue("SEURCH_NOT_RESULTS_TEXTBLOCK_TEXT");
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
                StatusMessage = _localizationService.GetValue("SEURCH_TEXTBOX_EMPTY_PLACEHOLDER_TEXT");
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
                StatusMessage = _localizationService.GetValue("PROBLEM_SERVER_ERROR");
                IsStatusMessageVisible = true;
                return;
            }

            Results = new ObservableCollection<UserModel>(executionResult.Result);
            if(Results.Count==0)
            {
                StatusMessage = _localizationService.GetValue("SEURCH_NOT_RESULTS_TEXTBLOCK_TEXT");
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
