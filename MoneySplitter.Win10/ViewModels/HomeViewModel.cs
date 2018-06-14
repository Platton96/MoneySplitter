using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Win10.Common;
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

		private UserModel _currentUserModel;
		private int _friendsCount;
		private TransactionEventModel _latestTransaction;
		private int _transactionsCount;
		private ObservableCollection<NotificationModel> _notifications;
		private int _notificationsCount;
		private bool _isLoading;

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
			TransactionEventModelFactory transactionsFactory)
		{
			_membershipService = membershipService;
			_friendsManager = friendsManager;
			_transactionsManager = transactionsManager;
			_transactionsFactory = transactionsFactory;
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

			await _friendsManager.LoadUserFriendsAsync();
			FriendsCount = _friendsManager.UserFriends.Count();

			await _transactionsManager.LoadUserTransactionsAsync();
			var userTransactions = _transactionsManager.UserTransactions;

			TransactionsCount = userTransactions.Count();
            if(TransactionsCount>0)
            {
                LatestTransaction = _transactionsFactory.GetTransactionEvent(userTransactions.First(), null, true);
            }
		
			ConfigureNotifications();

			IsLoading = false;

            var localisarionService = new LocalizationServise(Defines.Localization.RESOURCE_FILE_RU_PATCH);
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

	public class NotificationModel
	{
		public string ImageUrl { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
	}
}
