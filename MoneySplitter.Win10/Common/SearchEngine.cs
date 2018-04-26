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

        private string _messageForUser;
        private bool _ismessageForUserVisable=true;

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

        public string MessageForUser
        {
            get { return _messageForUser; }
            set
            {
                _messageForUser = value;
                NotifyOfPropertyChange(nameof(MessageForUser));
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

        public bool IsMessageForUserVisable
        {
            get { return _ismessageForUserVisable; }
            set
            {
                _ismessageForUserVisable = value;
                NotifyOfPropertyChange(nameof(IsMessageForUserVisable));
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
                MessageForUser = Defines.Search.TEXTBOX_EMPTY;
                IsMessageForUserVisable = true;
                _previousQuery = _query;
                return;
            }

            IsSearchInProgress = true;

            var executionResult = await _searchApiService.SearchUsersAsync(_query);

            _previousQuery = _query;
            if (!executionResult.IsSuccess)
            {
                Results?.Clear();
                MessageForUser = Defines.Search.PROBLEM_SERVER;
                IsMessageForUserVisable = true;
                return;
            }

            Results = new ObservableCollection<UserModel>(executionResult.Result);
            if(Results.Count==0)
            {
                MessageForUser = Defines.Search.NOT_RESULTS;
                IsMessageForUserVisable = true;
            }
            else
            {
                IsMessageForUserVisable = false;
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
