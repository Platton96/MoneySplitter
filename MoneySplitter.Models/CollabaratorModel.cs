using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class CollabaratorModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int FriendId { get; set; }
        public string ImageUrl { get; set; }
        public COLLABARATOR_STATUS CollabaratorStatus { get; set; }
        public TRANSACTION_STAYUS TransactionStatus { get; set; }
        public double Cost { get; set; }
    }

    public enum COLLABARATOR_STATUS
    {
        OneDebt,
        ManyDebt,
        OneLend,
        ManyLend
    }

    public enum TRANSACTION_STAYUS
    {
        InBegin,
        InProgress,
        InFinish,
        Undefined
    }
}
