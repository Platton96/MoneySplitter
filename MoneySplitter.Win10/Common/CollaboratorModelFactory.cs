using MoneySplitter.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using MoneySplitter.Models;
using System;

namespace MoneySplitter.Win10.Common
{
    public class CollaboratorModelFactory
    {
        private readonly ITransactionsManager _transactionsManager;
        private readonly IMembershipService _membershipService;

        public CollaboratorModelFactory(ITransactionsManager transactionsManager, IMembershipService membershipService)
        {
            _transactionsManager = transactionsManager;
            _membershipService = membershipService;
        }

        public IEnumerable<CollaboratorModel> GetDebtors()
        {
            return _transactionsManager.UserTransactions.Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id)
                .SelectMany(tr => ConvertTransactionModelToCollabaratorModel(tr, CollaboratorStatus.ONE_DEBT))
                .GroupBy
                (
                    cl => cl.Email,
                    cl => cl,
                    (key, value) => new { Email = key, CollaboratorRecords = value }
                )
                .Select(cl => ConvertCollaboratorRecordsToOneRecord(cl.CollaboratorRecords, CollaboratorStatus.MANY_DEBT));
        }

        public IEnumerable<CollaboratorModel> GetLendPersons()
        {
            return _transactionsManager.UserTransactions.Where(tr => tr.Owner.Id != _membershipService.CurrentUser.Id)
                .Select(
                            tr => ConvertDataToCollabatorModel(tr.Owner, tr, CollaboratorStatus.ONE_LEND,
                            GetTransactionStatus(_membershipService.CurrentUser, tr))
                       )
               .GroupBy
                (
                    cl => cl.Email,
                    cl => cl,
                    (key, value) => new { Email = key, CollaboratorRecords = value }
                )
                .Select(cl => ConvertCollaboratorRecordsToOneRecord(cl.CollaboratorRecords, CollaboratorStatus.MANY_LEND));
        }

        private IEnumerable<CollaboratorModel> ConvertTransactionModelToCollabaratorModel(TransactionModel transactionModel, CollaboratorStatus collabaratorStatus)
        {
            return transactionModel.Collaborators.Where(cl => cl.Id != _membershipService.CurrentUser.Id)
                     .Select(cl => ConvertDataToCollabatorModel(cl, transactionModel, collabaratorStatus, UserRole.IN_BEGIN))
                     .Concat(
                               transactionModel.InProgressIds.Where(id => id != _membershipService.CurrentUser.Id)
                               .Select(
                                       userId => ConvertDataToCollabatorModel(
                                                   GetCollaborator(userId, transactionModel), 
                                                   transactionModel, collabaratorStatus, UserRole.IN_PROGRESS
                                                 )     
                                      )
                            );
        }

        private CollaboratorModel ConvertDataToCollabatorModel(
            UserModel userModel,
            TransactionModel transactionModel,
            CollaboratorStatus collaboratorStatus,
            UserRole transactionStatus)
        {
            return new CollaboratorModel
            {
                FullName = $"{userModel.Name} {userModel.Surname}",
                Cost = Math.Round(transactionModel.SingleCost, Defines.Collaborator.COUNT_NUMBER_AFTER_POINT),
                CollaboratorStatus = collaboratorStatus,
                TransactionStatus = transactionStatus,
                Email = userModel.Email,
                FriendId = userModel.Id,
                ImageUrl = userModel.ImageUrl,
                TransactionId = transactionModel.Id
            };

        }

        private UserRole GetTransactionStatus(UserModel user, TransactionModel transaction)
        {
            if (transaction.InProgressIds.Any(id => id == user.Id))
            {
                return UserRole.IN_PROGRESS;
            }

            if (transaction.FinishedIds.Any(id => id == user.Id))
            {
                return UserRole.FINISHED;
            }

            if (transaction.Collaborators.Any(cl => cl.Id == user.Id))
            {
                return UserRole.IN_BEGIN;
            }
            return UserRole.UNDEFINED;
        }

        private CollaboratorModel ConvertCollaboratorRecordsToOneRecord(IEnumerable<CollaboratorModel> collabaratorRecords, CollaboratorStatus collaboratorStatusForManyRecords)
        {

            if (!collabaratorRecords.Any())
            {
                return collabaratorRecords.FirstOrDefault();
            }

            var firstRecord = collabaratorRecords.FirstOrDefault();

            return new CollaboratorModel
            {
                Email = firstRecord.Email,
                FullName = firstRecord.FullName,
                Cost = collabaratorRecords.Sum(r => r.Cost),
                CollaboratorStatus = collaboratorStatusForManyRecords,
                TransactionStatus = UserRole.UNDEFINED,
                ImageUrl = firstRecord.ImageUrl,
                FriendId = firstRecord.FriendId,
            };
        }

        private UserModel GetCollaborator(int collaboratorId, TransactionModel transactionModel)
        {
            return transactionModel.Collaborators
                .FirstOrDefault(user=>user.Id==collaboratorId);
        }

    }
}
