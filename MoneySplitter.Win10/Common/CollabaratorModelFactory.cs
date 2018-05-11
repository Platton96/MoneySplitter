using MoneySplitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySplitter.Models;

namespace MoneySplitter.Win10.Common
{
    public class CollabaratorModelFactory
    {
        private ITransactionsManager _transactionsManager;
        private IMembershipService _membershipService;

        public CollabaratorModelFactory(ITransactionsManager transactionsManager, IMembershipService membershipService )
        {
            _transactionsManager = transactionsManager;
            _membershipService = membershipService;
        }

        public IEnumerable<CollabaratorModel> GetDebtors()
        {
            return _transactionsManager.UserTransactions.Where(tr => tr.Owner.Id == _membershipService.CurrentUser.Id)
                .SelectMany(tr => ConvertTransactionModelToCollabaratorModel(tr, COLLABARATOR_STATUS.OneDebt))
                .GroupBy
                (
                    cl => cl.Email,
                    cl => cl,
                    (key, value) => new { Email = key, CollaboratorRecords = value }
                )
                .Select(cl => ConvertCollaboratorRecordsToOneRecord(cl.CollaboratorRecords, COLLABARATOR_STATUS.ManyDebt));
        }
         
        public IEnumerable<CollabaratorModel> GetLendPerson()
        {
            return _transactionsManager.UserTransactions.Where(tr => tr.Owner.Id != _membershipService.CurrentUser.Id)
                .Select(
                            tr => ConvertDataToCollabatorModel(tr.Owner, tr, COLLABARATOR_STATUS.OneLend, GetTransactionStatus(tr.Owner, tr))
                       )
               .GroupBy
                (
                    cl => cl.Email,
                    cl => cl,
                    (key, value) => new { Email = key, CollaboratorRecords = value }
                )
                .Select(cl => ConvertCollaboratorRecordsToOneRecord(cl.CollaboratorRecords, COLLABARATOR_STATUS.ManyLend));
        }

        private IEnumerable<CollabaratorModel> ConvertTransactionModelToCollabaratorModel(TransactionModel transactionModel, COLLABARATOR_STATUS collabaratorStatus)
        {
           return transactionModel.Collaborators.Where(cl => cl.Id != _membershipService.CurrentUser.Id)
                    .Select(cl => ConvertDataToCollabatorModel(cl, transactionModel, collabaratorStatus, TRANSACTION_STAYUS.InBegin))
                    .Concat(
                              transactionModel.InProgress.Where(user => user.Id != _membershipService.CurrentUser.Id)
                              .Select(user => ConvertDataToCollabatorModel(user, transactionModel, collabaratorStatus, TRANSACTION_STAYUS.InProgress))
                           );


        }
        
        private CollabaratorModel ConvertDataToCollabatorModel(
            UserModel userModel,
            TransactionModel transactionModel,
            COLLABARATOR_STATUS collabaratorStatus,
            TRANSACTION_STAYUS transactionStatus)
        {
            return new CollabaratorModel
            {
                FullName = userModel.Name + " " + userModel.Surname,
                Cost = transactionModel.SingleCost,
                CollabaratorStatus = collabaratorStatus,
                TransactionStatus=transactionStatus,
                Email=userModel.Email,
            };

        }

        private TRANSACTION_STAYUS GetTransactionStatus(UserModel user, TransactionModel transaction)
        {
            if(transaction.Collaborators.Any(cl=>cl==user))
            {
                return TRANSACTION_STAYUS.InBegin;
            }

            if(transaction.InProgress.Any(cl=>cl==user))
            {
                return TRANSACTION_STAYUS.InProgress;
            }

            if (transaction.Finished.Any(cl=>cl==user))
            {
                return TRANSACTION_STAYUS.InFinish;
            }

            return TRANSACTION_STAYUS.Undefined;
        }
        
        private CollabaratorModel ConvertCollaboratorRecordsToOneRecord(IEnumerable<CollabaratorModel> collabaratorRecords, COLLABARATOR_STATUS collabaratorStatusForManyRecords)
        {
            if(collabaratorRecords.Count()==1)
            {
                return collabaratorRecords.FirstOrDefault();
            }

            return new CollabaratorModel
            {
                Email = collabaratorRecords.FirstOrDefault().Email,
                FullName = collabaratorRecords.FirstOrDefault().FullName,
                Cost = collabaratorRecords.Sum(r => r.Cost),
                CollabaratorStatus = collabaratorStatusForManyRecords,
                TransactionStatus = TRANSACTION_STAYUS.Undefined
            };
        }
    }
}
