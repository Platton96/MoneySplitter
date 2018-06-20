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

        private readonly IMembershipService _membershipService;
        private readonly INavigationManager _navigationManager;

        private string _titleFrameText;
        private UserModel _userModel;
        private string _selectedMenuItem;
        private ILocalizationService _localizationService;

        private IDictionary<string, Type> _mainMenuPages;

        #endregion

        #region Properties


        public string SelectedMenuItem
        {
            get => _selectedMenuItem;
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

        public IEnumerable<string> MenuItems => _mainMenuPages.Select(w => w.Key).ToList();

        public UserModel UserModel
        {
            get => _userModel; 
            set
            {
                _userModel = value;
                NotifyOfPropertyChange(nameof(UserModel));
            }
        }

        public string TitleFrameText
        {
            get => _titleFrameText; 
            set
            {
                _titleFrameText = value;
                NotifyOfPropertyChange(nameof(TitleFrameText));
            }
        }

        #endregion

        #region Constructor
        public ShellViewModel(IMembershipService membershipService, INavigationManager navigationManager, ILocalizationService localizationService)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
            _localizationService = localizationService;

            _titleFrameText = _localizationService.GetValue("HOME_FRAME_TITLE");
            InitializeMenuItems();
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
            if (value == null)
            {
                return;
            }

            _navigationManager.NavigateToShellViewModel(_mainMenuPages[value]);
        }

        public void NovigaateToFoundUsers()
        {
            _navigationManager.NavigateToSearchUsersViewModel();
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
        
        private void InitializeMenuItems()
        {
            _mainMenuPages = new Dictionary<string, Type>()
            {
                {
                    string.Format(
                        MAIN_MENU_BUTTON_TEMPLATE,
                        Defines.MenuItem.IconButton.HOME,
                        _localizationService.GetValue("HOME_FRAME_TITLE")),

                    typeof(HomeViewModel)
                },
                {
                string.Format(
                    MAIN_MENU_BUTTON_TEMPLATE,
                    Defines.MenuItem.IconButton.FRIENDS,
                    _localizationService.GetValue("FRIENDS_FRAME_TITLE")),

                typeof(FriendsViewModel)
                },
                {
                    string.Format(
                        MAIN_MENU_BUTTON_TEMPLATE,
                        Defines.MenuItem.IconButton.SEARCH,
                        _localizationService.GetValue("SEARCH_FRAME_TITLE")),

                    typeof(SearchUsersViewModel)
                },
                {
                    string.Format(
                        MAIN_MENU_BUTTON_TEMPLATE,
                        Defines.MenuItem.IconButton.TRANSACTIONS,
                        _localizationService.GetValue("TRANSACTIONS_FRAME_TITLE")),

                    typeof(TransactionsViewModel)
                },
                {
                    string.Format(
                        MAIN_MENU_BUTTON_TEMPLATE,
                        Defines.MenuItem.IconButton.INCOMING_AND_OUTCOMING,
                       _localizationService.GetValue("INCOMING_AND_OUTGOING_FRAME_TITLE")),

                    typeof(IncomingAndOutgoingViewModel)
                }
            };
        }

        #endregion
    }
}
