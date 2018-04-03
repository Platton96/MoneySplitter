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
        private IMembershipService _membershipService;
        private readonly INavigationManager _navigationManager;

        private UserModel _userModel;

        private IDictionary<string, Type> _mainMenuPages = new Dictionary<string, Type>()
        {
            {"Friends",  typeof(FriendsViewModel)},
            {"Home", typeof(HelloWorldViewModel) }
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

        public ShellViewModel(IMembershipService membershipService, INavigationManager navigationManager)
        {
            _membershipService = membershipService;
            _navigationManager = navigationManager;
        }

        public void InitializeShellNavigationService(Frame frame)
        {
            _navigationManager.InitializeShellNavigationService(new FrameAdapter(frame));

            _navigationManager.NavigateToShellViewModel();
        }

        public void NavigateToClikedItemMenu(string value)
        {
            _navigationManager.NavigateToShellViewModel(_mainMenuPages[value]);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            UserModel = _membershipService.CurrentUser;
        }
    }

}
