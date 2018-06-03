using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneySplitter.Win10.Common
{
	public class TransactionEventModelFactory
	{
		private readonly ITransactionsManager _transactionsManager;
		private readonly IMembershipService _membershipService;

		public TransactionEventModelFactory(ITransactionsManager transactionsManager, IMembershipService membershipService)
		{
			_transactionsManager = transactionsManager;
			_membershipService = membershipService;
		}

		public IEnumerable<TransactionEventModel> GetTransactionEvents(IEnumerable<TransactionModel> friendTransactions,
			int? friendId = null,
			bool isForceHide = false,
			bool isDeadLineShowed = false)
		{
			return friendTransactions
                .Select(tr => ConvertTransactionModelToTransactionEventModel(tr, friendId, isForceHide, isDeadLineShowed));
		}
        public IEnumerable<TransactionEventModel> GetFriendDebts(IEnumerable<TransactionModel> friendTransactions, int friendId)
        {
            return GetTransactionEvents(friendTransactions.
                Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id), friendId, false, true);
     
        }

        public IEnumerable<TransactionEventModel> GetFriendLends(IEnumerable<TransactionModel> friendTransactions, int friendId)
        {

            return GetTransactionEvents(friendTransactions.
                Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id), friendId);
        }

        public TransactionEventModel GetTransactionEvent(TransactionModel friendTransaction,
			int? friendId = null,
			bool isForceHide = false,
			bool isDeadLineShowed = false)
		{
			return ConvertTransactionModelToTransactionEventModel(friendTransaction, friendId, isForceHide, isDeadLineShowed);
		}

		private UserRole GetUserRole(int userId, TransactionModel transaction)
		{
			if (transaction.Owner.Id == userId)
			{
				return UserRole.USER_TRANSACTION;
			}
			if (transaction.InProgressIds.Any(id => id == userId))
			{
				return UserRole.IN_PROGRESS;
			}

			if (transaction.FinishedIds.Any(id => id == userId))
			{
				return UserRole.FINISHED;
			}

			if (transaction.Collaborators.Any(cl => cl.Id == userId))
			{
				return UserRole.IN_BEGIN;
			}
			return UserRole.UNDEFINED;
		}

		private UserRole GetFriendRole(int? friendId, TransactionModel transactionModel)
		{
			if (friendId == null)
			{
				return UserRole.UNDEFINED;
			}
			return GetUserRole((int)friendId, transactionModel);
		}
		private int GetNotVisibilCollabarratorsCount(TransactionModel transactionModel)
		{
			var VisibilUserWithoutMeAndOwnerCount = transactionModel.Owner.Id == _membershipService.CurrentUser.Id ? 2 : 1;

			return transactionModel.Collaborators.Count(cl => cl.Id != transactionModel.Owner.Id &&
															  cl.Id != _membershipService.CurrentUser.Id) - VisibilUserWithoutMeAndOwnerCount;

		}

		private IEnumerable<string> GetVicibilCollaboratorsImageUrls(TransactionModel transactionModel)
		{
			const int MAX_COUNT_IMAGE = 4;
			var OwnerAndMe = new List<string>();
			OwnerAndMe.Add(transactionModel.Owner.ImageUrl);

			if (transactionModel.Owner.Id != _membershipService.CurrentUser.Id)
			{
				OwnerAndMe.Add(_membershipService.CurrentUser.ImageUrl);
			}

			var allCollaborators = OwnerAndMe.Concat(transactionModel.Collaborators.
														Where(cl => cl.Id != transactionModel.Owner.Id && cl.Id != _membershipService.CurrentUser.Id)
														.Select(cl => cl.ImageUrl));

			return allCollaborators.Count() <= MAX_COUNT_IMAGE ? allCollaborators : allCollaborators.Take(MAX_COUNT_IMAGE - 1);
		}

		private TypeDate GetTypeDate(TransactionModel transactionModel, bool IsDeadLineShowed)
		{
			if (IsDeadLineShowed ||
				transactionModel.OngoingDate == null ||
				transactionModel.DeadlineDate < transactionModel.OngoingDate)
			{
				return TypeDate.DEADLINE_DATE;
			}

			return TypeDate.ONGOIND_DATE;
		}

		private DateTime GetDate(TypeDate typeDate, TransactionModel transactionModel)
		{
			if (typeDate == TypeDate.DEADLINE_DATE)
			{
				return transactionModel.DeadlineDate;
			}

			return (DateTime)transactionModel.OngoingDate;
		}

		private TransactionEventModel ConvertTransactionModelToTransactionEventModel(TransactionModel transactionModel,
			int? friendId,
			bool isForceHide,
			bool isDeadLineShowed)
		{
			var typeDate = GetTypeDate(transactionModel, isDeadLineShowed);
			return new TransactionEventModel
			{
				Title = transactionModel.Title,
				SingleCost = Math.Round(transactionModel.SingleCost, Defines.Collaborator.COUNT_NUMBER_AFTER_POINT),
				UserRole = GetUserRole(_membershipService.CurrentUser.Id, transactionModel),
				FriendRole = GetFriendRole(friendId, transactionModel),
				TypeDate = typeDate,
				Date = GetDate(typeDate, transactionModel),
				NotVisibilCollabarratorsCount = GetNotVisibilCollabarratorsCount(transactionModel),
				CollaboratorImageUrls = GetVicibilCollaboratorsImageUrls(transactionModel),
				TransactionId = transactionModel.Id,
				ImageUrl = transactionModel.ImageUrl,
				IsForceHide = isForceHide,
				RootTransaction = transactionModel
			};
		}
	}

}