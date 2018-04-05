﻿using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Caliburn.Micro;
using MoneySplitter.Infrastructure;

namespace MoneySplitter.Win10.Common
{
    public class SearchEngine : PropertyChangedBase
    {
        private readonly DispatcherTimer _timer;

        private readonly ISearchApiService _searchApiService;
        private bool _isSearchInProgress;
        private string _previousQuery = string.Empty;
        private string _query;

        private TimeSpan TIMER_INTERVAL = TimeSpan.FromSeconds(3);

        private IList<UserModel> _results;

        public IList<UserModel> Results
        {
            get => _results;
            set
            {
                _results = value;
                NotifyOfPropertyChange(nameof(Results));
            }
        }

        public string Query
        {
            get { return _query; }
            set
            {
                _query = value;
                NotifyOfPropertyChange(nameof(Query));
            }
        }

        public SearchEngine()
        {
            _timer = new DispatcherTimer
            {
                Interval = TIMER_INTERVAL
            };

            _timer.Tick += OnTimerTick;
        }

        private async void OnTimerTick(object sender, object e)
        {
            await PerformUsersSearchAsync();
        }

        public void Activate()
        {
            _timer.Start();
        }

        public async Task PerformUsersSearchAsync()
        {
            if (_isSearchInProgress || Query == _previousQuery)
            {
                return;
            }

            if (string.IsNullOrEmpty(Query))
            {
                Results.Clear();
                return;
            }

            _isSearchInProgress = true;

           // Results = await _searchApiService.SearchUsers(Query).ToList();

            _isSearchInProgress = false;
        }

        public void Deactivate()
        {
            _timer.Stop();
        }
    }
}
