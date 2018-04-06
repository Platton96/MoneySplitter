using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using System.Linq;

namespace MoneySplitter.Win10.Common
{
    public class SearchEngine : PropertyChangedBase
    {
        private readonly ISearchApiService _searchApiService;
        private bool _isSearchInProgress;

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

        public SearchEngine(ISearchApiService searchApiService )
        { 
            _searchApiService = searchApiService;
            _isSearchInProgress = true;
        }

        public async Task PerformUsersSearchAsync(string query)
        {
            if(string.IsNullOrEmpty(query))
            {
                Results?.Clear();
                return;
            }
            if (_isSearchInProgress==true)
            {
                _isSearchInProgress = false;
                Results?.Clear();
                var responce = await _searchApiService.SearchUsersAsync(query);
                Results = responce.ToList();

                _isSearchInProgress = true;
            }
        }
    }
}
