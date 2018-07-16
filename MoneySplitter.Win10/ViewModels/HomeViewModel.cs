using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using MoneySplitter.Win10.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoneySplitter.Win10.ViewModels
{
    public class HomeViewModel : Screen
    {
        private readonly IMembershipService _membershipService;
        private readonly IFriendsManager _friendsManager;
        private readonly ITransactionsManager _transactionsManager;
        private readonly TransactionEventModelFactory _transactionsFactory;
        private readonly INavigationManager _navigationManager;
        private IEnumerable<TransactionModel> _userTransactions;
        private readonly ILocalizationService _localizationService;

        private UserModel _currentUserModel;
        private int _friendsCount;
        private TransactionEventModel _latestTransaction;
        private int _transactionsCount;
        private ObservableCollection<NotificationModel> _notifications;
        private int _notificationsCount;
        private bool _isLoading;
        private bool _isErrorVisible;
        private double _debt;
        private double _lend;
        private double _inProgress;
        private double _inComming;
        private ErrorDetailsModel _errorDetailsModel;

        public bool IsNotificationsSectionAvailable => Notifications?.Count > 0;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                NotifyOfPropertyChange(nameof(IsErrorVisible));
            }
        }

        public ErrorDetailsModel ErrorDetailsModel
        {
            get => _errorDetailsModel;
            set
            {
                _errorDetailsModel = value;
                NotifyOfPropertyChange(nameof(ErrorDetailsModel));
            }
        }

        public int NotificationsCount
        {
            get => _notificationsCount;
            set
            {
                _notificationsCount = value;
                NotifyOfPropertyChange(nameof(NotificationsCount));
            }
        }

        public ObservableCollection<NotificationModel> Notifications
        {
            get => _notifications;
            set
            {
                _notifications = value;
                NotifyOfPropertyChange(nameof(Notifications));
            }
        }

        public UserModel CurrentUserModel
        {
            get => _currentUserModel;
            set
            {
                _currentUserModel = value;
                NotifyOfPropertyChange(nameof(CurrentUserModel));
            }
        }

        public int TransactionsCount
        {
            get => _transactionsCount;
            set
            {
                _transactionsCount = value;
                NotifyOfPropertyChange(nameof(TransactionsCount));
            }
        }

        public int FriendsCount
        {
            get => _friendsCount;
            set
            {
                _friendsCount = value;
                NotifyOfPropertyChange(nameof(FriendsCount));
            }
        }

        public double Debt
        {
            get => _debt;
            set
            {
                _debt = value;
                NotifyOfPropertyChange(nameof(Debt));
            }
        }

        public double Lend
        {
            get => _lend;
            set
            {
                _lend = value;
                NotifyOfPropertyChange(nameof(Lend));
            }
        }
        public double InProgress
        {
            get => _inProgress;
            set
            {
                _inProgress = value;
                NotifyOfPropertyChange(nameof(InProgress));
            }
        }

        public double InComming
        {
            get => _inComming;
            set
            {
                _inComming = value;
                NotifyOfPropertyChange(nameof(InComming));
            }
        }
        public TransactionEventModel LatestTransaction
        {
            get => _latestTransaction;
            set
            {
                _latestTransaction = value;
                NotifyOfPropertyChange(nameof(LatestTransaction));
            }
        }

        public HomeViewModel(
            IMembershipService membershipService,
            IFriendsManager friendsManager,
            ITransactionsManager transactionsManager,
            TransactionEventModelFactory transactionsFactory,
            INavigationManager navigationManager,
            ILocalizationService localizationService)
        {
            _membershipService = membershipService;
            _friendsManager = friendsManager;
            _transactionsManager = transactionsManager;
            _transactionsFactory = transactionsFactory;
            _navigationManager = navigationManager;
            _localizationService = localizationService;
        }

        public void RemoveNotification(NotificationModel notification)
        {
            Notifications.Remove(notification);
            NotifyOfPropertyChange(nameof(IsNotificationsSectionAvailable));
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            IsLoading = true;

            CurrentUserModel = _membershipService.CurrentUser;

            var executionResultFriendsManager = await _friendsManager.GetUserFriendsAsync();

            var executionResultTransactionManager = await _transactionsManager.GetUserTransactionsAsync();

            if (!executionResultTransactionManager.IsSuccess || !executionResultFriendsManager.IsSuccess)
            {
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.DEFAULT_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.PROBLEM_SERVER_ERROR)
                };

                IsErrorVisible = true;
                return;
            }
            FriendsCount = executionResultFriendsManager.Result.Count();

            _userTransactions = executionResultTransactionManager.Result;

            TransactionsCount = _userTransactions.Count();
            if (TransactionsCount > 0)
            {
                LatestTransaction = _transactionsFactory.GetTransactionEvent(_userTransactions.First(), null, true);
            }
            CalculateStatistic();
            ConfigureNotifications();

            IsLoading = false;

        }

        public void NavigateToTransactionDetails()
        {
            _navigationManager.NavigateToTransactionDetailsViewModel(LatestTransaction);
        }

        private void CalculateStatistic()
        {
            Debt = _userTransactions
                .Where(tr => tr.Owner.Id != _membershipService.CurrentUser.Id)
                .Sum(tr => tr.SingleCost);
            Debt = Math.Round(Debt, Defines.Collaborator.COUNT_NUMBER_AFTER_POINT);
            Lend = _userTransactions
                .Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id)
                .Sum(tr => tr.SingleCost);
            Lend = Math.Round(Lend, Defines.Collaborator.COUNT_NUMBER_AFTER_POINT);
            InProgress = _userTransactions
                .Where(tr => tr.Owner.Id != _membershipService.CurrentUser.Id
                             && tr.InProgressIds.Contains(_membershipService.CurrentUser.Id))
                .Sum(tr => tr.SingleCost);
            InProgress = Math.Round(InProgress, Defines.Collaborator.COUNT_NUMBER_AFTER_POINT);
            InComming = _userTransactions
                    .Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id)
                    .Sum(tr => tr.InProgressIds.Count() * tr.SingleCost);
            InComming = Math.Round(InComming, Defines.Collaborator.COUNT_NUMBER_AFTER_POINT);
        }
        private void ConfigureNotifications()
        {
            Notifications = new ObservableCollection<NotificationModel>(
            new[]
            {
                new NotificationModel
                {
                    ImageUrl = "https://memepedia.ru/wp-content/uploads/2018/05/cover-2-4.jpg",
                    Text = "Reminds you to pay debt \"Ичираку рамен с друзьями и братюней\"",
                    Title = "Дэниэ Рэдклиф"
                },
                new NotificationModel
                {
                    ImageUrl = "http://i.playground.ru/i/17/21/21/00/blog/content/ey6rz7g5.png",
                    Text = "Approved your input for transaction \"Долг за убийство Чезаре Борджиа\"",
                    Title = "Эцио Аудиторе"
                },
                new NotificationModel
                {
                    ImageUrl = "https://i.ytimg.com/vi/k2mm2bXiTaY/hqdefault.jpg",
                    Text = "Added you to friends",
                    Title = "Чиригг Акхиашьян"
                },
                new NotificationModel
                {
                    ImageUrl = "http://statici.behindthevoiceactors.com/behindthevoiceactors/_img/chars/markus-detroit-become-human-4.08.jpg",
                    Text = "Reminds you to pay debt \"Деньги на революцио против человеков\"",
                    Title = "Маркус Девиантович"
                }
            } as IEnumerable<NotificationModel>);

            NotificationsCount = Notifications.Count();
            NotifyOfPropertyChange(nameof(IsNotificationsSectionAvailable));
        }
    }

}
