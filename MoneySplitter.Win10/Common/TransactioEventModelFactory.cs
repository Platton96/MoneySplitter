using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneySplitter.Win10.Common
{
    public class TransactioEventModelFactory
    {
        private readonly ITransactionsManager _transactionsManager;
        private readonly IMembershipService _membershipService;

        public TransactioEventModelFactory(ITransactionsManager transactionsManager, IMembershipService membershipService)
        {
            _transactionsManager = transactionsManager;
            _membershipService = membershipService;
        }

        public IEnumerable<TransactionEventModel> GetTransactionEvents(IEnumerable<TransactionModel> friendTransactions)
        {
            return friendTransactions.Select(tr => ConvertTransactionModelToTransactionEventModel(tr));
        }

        private UserRole GetUserRole(int userId, TransactionModel transaction)
        {
            if (transaction.Owner.Id == userId)
            {
                return UserRole.UserTransaction;
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

        private DateTime GetDate(TransactionModel transactionModel)
        {
            if (transactionModel.OngoingDate == null ||
                transactionModel.DeadlineDate < transactionModel.OngoingDate)
            {
                return transactionModel.DeadlineDate;
            }

            return transactionModel.OngoingDate;
        }

        private TransactionEventModel ConvertTransactionModelToTransactionEventModel(TransactionModel transactionModel)
        {
            return new TransactionEventModel
            {
                Title = transactionModel.Title,
                SingleCost = transactionModel.SingleCost,
                UserRole = GetUserRole(_membershipService.CurrentUser.Id, transactionModel),
                Date = GetDate(transactionModel),
                NotVisibilCollabarratorsCount = GetNotVisibilCollabarratorsCount(transactionModel),
                CollaboratorImageUrls = GetVicibilCollaboratorsImageUrls(transactionModel),
                TransactionId = transactionModel.Id
            };
        }
    }

}