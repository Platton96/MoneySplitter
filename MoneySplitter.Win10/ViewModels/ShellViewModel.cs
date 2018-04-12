using Caliburn.Micro;
using MoneySplitter.Models;
using MoneySplitter.Infrastructure;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MoneySplitter.Win10.ViewModels
{
    public class ShellViewModel : Screen
    {
        #region Fields
        private const string MAIN_MENU_BUTTON_TEMPLATE = "{0} {1}";
        private const string WELCOME = "Welcome";

        private readonly IMembershipService _membershipService;
        private readonly INavigationManager _navigationManager;

        private string _titleFrameText = WELCOME;
        private UserModel _userModel;
        private string _searchQuery;
        private string _selectedMenuItem;
        #endregion

        #region Properties
        private IDictionary<string, Type> _mainMenuPages = new Dictionary<string, Type>()
        {
            { string.Format(MAIN_MENU_BUTTON_TEMPLATE, Defines.IconButton.HOME, Defines.Title.HOME),  typeof(HomeViewModel) },
            { string.Format(MAIN_MENU_BUTTON_TEMPLATE, Defines.IconButton.FRIENDS, Defines.Title.FRIENDS), typeof(FriendsViewModel) },
            { string.Format(MAIN_MENU_BUTTON_TEMPLATE, Defines.IconButton.SEARCH, Defines.Title.SEARCH),typeof(FoundUsersViewModel) }
        };

        public string SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (value == SelectedMenuItem)
                {
                    return;
                }

                _selectedMenuItem = value;
                NotifyOfPropertyChange(nameof(SelectedMenuItem));
                NavigateToClikedItemMenu(value);
            }
        }

        public IEnumerable<string> MenuItems => _mainMenuPages.Select(w => w.Key);

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
        #endregion

        #region Constructor
        public ShellViewModel(IMembershipService membershipService, INavigationManager navigationManager)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
        }
        #endregion

        #region Public methods
        public void InitializeShellNavigationService(Frame frame)
        {
            _navigationManager.InitializeShellNavigationService(new FrameAdapter(frame));

            SelectedMenuItem = MenuItems.First();
        }

        public void NavigateToClikedItemMenu(string value)
        {
            _navigationManager.NavigateToShellViewModel(_mainMenuPages[value]);
        }

        public void NovigaateToFoundUsers()
        {
            _navigationManager.NavigateToFoundUsersViewModel();
        }
        #endregion

        #region Protected methods
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
        #endregion

        #region Private methods
        private void OnNavigated(object sender, Type e)
        {
            TitleFrameText = _mainMenuPages.FirstOrDefault(w => w.Value == e).Key;

            SelectedMenuItem = MenuItems.FirstOrDefault(w => w == TitleFrameText);
        }
        #endregion
    }
}
