namespace MoneySplitter.Models
{
    public class CollaboratorModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int FriendId { get; set; }
        public string ImageUrl { get; set; }
        public CollaboratorStatus CollaboratorStatus { get; set; }
        public UserRole TransactionStatus { get; set; }
        public int TransactionId { get; set; }
        public double Cost { get; set; }
        public bool IsGiveButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_LEND && TransactionStatus == UserRole.IN_BEGIN;
        public bool IsRemindButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_DEBT && TransactionStatus == UserRole.IN_BEGIN;
        public bool IsApproveButtonVisibil => CollaboratorStatus == CollaboratorStatus.ONE_DEBT && TransactionStatus == UserRole.IN_PROGRESS;
    }
}
