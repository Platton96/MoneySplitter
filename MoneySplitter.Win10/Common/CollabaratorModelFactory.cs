using MoneySplitter.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using MoneySplitter.Models;
using System;

namespace MoneySplitter.Win10.Common
{
    public class CollabaratorModelFactory
    {
        private ITransactionsManager _transactionsManager;
        private IMembershipService _membershipService;

        public  CollabaratorModelFactory(ITransactionsManager transactionsManager, IMembershipService membershipService )
        {
            _transactionsManager = transactionsManager;
            _membershipService = membershipService;
        }

        public IEnumerable<CollabaratorModel> GetDebtors()
        {
            return _transactionsManager.UserTransactions.Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id)
                .SelectMany(tr => ConvertTransactionModelToCollabaratorModel(tr, CollabaratorStatus.ONE_DEBT))
                .GroupBy
                (
                    cl => cl.Email,
                    cl => cl,
                    (key, value) => new { Email = key, CollaboratorRecords = value }
                )
                .Select(cl => ConvertCollaboratorRecordsToOneRecord(cl.CollaboratorRecords, CollabaratorStatus.MANY_DEBT));
        }
         
        public IEnumerable<CollabaratorModel> GetLendPersons()
        {
            return _transactionsManager.UserTransactions.Where(tr => tr.Owner.Id != _membershipService.CurrentUser.Id)
                .Select(
                            tr => ConvertDataToCollabatorModel(tr.Owner, tr, CollabaratorStatus.ONE_LEND, GetTransactionStatus(_membershipService.CurrentUser, tr))
                       )
               .GroupBy
                (
                    cl => cl.Email,
                    cl => cl,
                    (key, value) => new { Email = key, CollaboratorRecords = value }
                )
                .Select(cl => ConvertCollaboratorRecordsToOneRecord(cl.CollaboratorRecords, CollabaratorStatus.MANY_LEND));
        }

        private IEnumerable<CollabaratorModel> ConvertTransactionModelToCollabaratorModel(TransactionModel transactionModel, CollabaratorStatus collabaratorStatus)
        {
           return transactionModel.Collaborators.Where(cl => cl.Id != _membershipService.CurrentUser.Id)
                    .Select(cl => ConvertDataToCollabatorModel(cl, transactionModel, collabaratorStatus, TransactionStatus.IN_BEGIN))
                    .Concat(
                              transactionModel.InProgress.Where(user => user.Id != _membershipService.CurrentUser.Id)
                              .Select(user => ConvertDataToCollabatorModel(user, transactionModel, collabaratorStatus, TransactionStatus.IN_PROGRESS))
                           );


        }
        
        private CollabaratorModel ConvertDataToCollabatorModel(
            UserModel userModel,
            TransactionModel transactionModel,
            CollabaratorStatus collabaratorStatus,
            TransactionStatus transactionStatus)
        {
            return new CollabaratorModel
            {
                FullName = userModel.Name + " " + userModel.Surname,
                Cost = Math.Round(transactionModel.SingleCost, 2),
                CollabaratorStatus = collabaratorStatus,
                TransactionStatus=transactionStatus,
                Email=userModel.Email,
                FriendId=userModel.Id,
                ImageUrl=userModel.ImageUrl
            };

        }

        private TransactionStatus GetTransactionStatus(UserModel user, TransactionModel transaction)
        {
            if(transaction.Collaborators.Any(cl=>cl.Id == user.Id))
            {
                return TransactionStatus.IN_BEGIN;
            }

            if(transaction.InProgress.Any(cl=>cl.Id == user.Id))
            {
                return TransactionStatus.IN_PROGRESS;
            }

            if (transaction.Finished.Any(cl=>cl.Id == user.Id))
            {
                return TransactionStatus.IN_FINISH;
            }

            return TransactionStatus.UNDEFINED;
        }
        
        private CollabaratorModel ConvertCollaboratorRecordsToOneRecord(IEnumerable<CollabaratorModel> collabaratorRecords, CollabaratorStatus collabaratorStatusForManyRecords)
        {
           
            if(collabaratorRecords.Count() == 1 )
            {

                return collabaratorRecords.FirstOrDefault();
            }
            var firstRecord = collabaratorRecords.FirstOrDefault();
            return new CollabaratorModel
            {
                Email = firstRecord.Email,
                FullName = firstRecord.FullName,
                Cost = collabaratorRecords.Sum(r => r.Cost),
                CollabaratorStatus = collabaratorStatusForManyRecords,
                TransactionStatus = TransactionStatus.UNDEFINED,
                ImageUrl= firstRecord.ImageUrl,
                FriendId= firstRecord.FriendId
            };
        }
    }
}
