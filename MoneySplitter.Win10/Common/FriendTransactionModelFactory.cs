using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneySplitter.Win10.Common
{
    public class FriendTransactionModelFactory
    {
        private readonly ITransactionsManager _transactionsManager;
        private readonly IMembershipService _membershipService;

        public FriendTransactionModelFactory(ITransactionsManager transactionsManager, IMembershipService membershipService)
        {
            _transactionsManager = transactionsManager;
            _membershipService = membershipService;
        }

        public IEnumerable<FriendTransactionModel> GetFriendDebts(IEnumerable<TransactionModel> friendTransactions, int friendId)
        {
            return friendTransactions.Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id)
                .Select(tr => ConvertTransactionModelToFriendTransactionModel(
                    tr,
                    CollaboratorStatus.ONE_DEBT,
                    GetUserRole(friendId, tr)
                    ));
        }

        public IEnumerable<FriendTransactionModel> GetFriendLends(IEnumerable<TransactionModel> friendTransactions, int friendId)
        {
            return friendTransactions.Where(tr => tr.Owner.Id == friendId)
                .Select(tr => ConvertTransactionModelToFriendTransactionModel(
                    tr,
                    CollaboratorStatus.ONE_LEND,
                    GetUserRole(_membershipService.CurrentUser.Id, tr)
                    ));
        }

        private FriendTransactionModel ConvertTransactionModelToFriendTransactionModel(
            TransactionModel transactionModel,
            CollaboratorStatus collaboratorStatus,
            UserRole userRole)
        {
            return new FriendTransactionModel
            {
                Title = transactionModel.Title,
                ImageUrl = transactionModel.ImageUrl,
                SingleCost = transactionModel.SingleCost,
                DeadlineDate = transactionModel.DeadlineDate,
                TransactionId = transactionModel.Id,
                UserRole = userRole,
                CollaboratorStatus = collaboratorStatus
            };
        }

        private UserRole GetUserRole(int userId, TransactionModel transaction)
        {
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
    }
}
