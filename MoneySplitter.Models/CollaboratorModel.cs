namespace MoneySplitter.Models
{
    public class CollaboratorModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int FriendId { get; set; }
        public string ImageUrl { get; set; }
        public CollaboratorStatus CollaboratorStatus { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public int TransactionId { get; set; }
        public double Cost { get; set; }
        public bool IsGiveButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_LEND && TransactionStatus == TransactionStatus.IN_BEGIN;
        public bool IsRemindButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_DEBT && TransactionStatus == TransactionStatus.IN_BEGIN;
        public bool IsApproveButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_DEBT && TransactionStatus == TransactionStatus.IN_PROGRESS;
    }
}
