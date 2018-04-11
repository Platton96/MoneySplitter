using Caliburn.Micro;
using MoneySplitter.Models;
using MoneySplitter.Infrastructure;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System;

namespace MoneySplitter.Win10.ViewModels
{
    public class ShellViewModel : Screen
    {
        private const string WELCOME = "Welcome";

        private IMembershipService _membershipService;
        private readonly INavigationManager _navigationManager;

        private string _titleFrameText= WELCOME;

        private UserModel _userModel;

        private string _searchQuery;

        private IDictionary<string, Type> _mainMenuPages = new Dictionary<string, Type>()
        {
            { "Friends",  typeof(FriendsViewModel) },
            { "Home", typeof(HelloWorldViewModel) },
            { "Search",typeof(FoundUsersViewModel) }
        };

        public UserModel UserModel
        {
            get { return _userModel; }
            set
            {
                _userModel = value;
                NotifyOfPropertyChange(nameof(UserModel));
            }
        }

        public string TitleFrameText
        {
            get { return _titleFrameText; }
            set
            {
                _titleFrameText = value;
                NotifyOfPropertyChange(nameof(TitleFrameText));
            }
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                NotifyOfPropertyChange(nameof(SearchQuery));
            }
        }

        public ShellViewModel(IMembershipService membershipService, INavigationManager navigationManager)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
        }

        public void InitializeShellNavigationService(Frame frame)
        {
            _navigationManager.InitializeShellNavigationService(new FrameAdapter(frame));

            _navigationManager.NavigateToMainPage();
        }

        public void NavigateToClikedItemMenu(string value)
        {
            TitleFrameText = value;
            _navigationManager.NavigateToShellViewModel(_mainMenuPages[value]);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            UserModel = _membershipService.CurrentUser;
            _navigationManager.OnShellNavigationManagerNavigated += OnNavigated;
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);

            _navigationManager.OnShellNavigationManagerNavigated -= OnNavigated;
        }

        private void OnNavigated(object sender, EventArgs e)
        {
            //TODO update main menu button and title
        }

        public void NovigaateToFoundUsers()
        {
            _navigationManager.NavigateToFoundUsersViewModel();
        }
    }
}
