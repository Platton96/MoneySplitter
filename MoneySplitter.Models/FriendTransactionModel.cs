using System;

namespace MoneySplitter.Models
{
    public class FriendTransactionModel
    {
        public string Title { get; set; }
        public DateTime DeadlineDate { get; set; }
        public double SingleCost { get; set; }
        public string ImageUrl { get; set; }
        public int TransactionId { get; set; }
        public CollaboratorStatus CollaboratorStatus { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsGiveButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_LEND && UserRole == UserRole.IN_BEGIN;
        public bool IsRemindButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_DEBT && UserRole == UserRole.IN_BEGIN;
        public bool IsApproveButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_DEBT && UserRole == UserRole.IN_PROGRESS;

    }
}
