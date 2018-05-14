using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class CollabaratorModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int FriendId { get; set; }
        public string ImageUrl { get; set; }
        public CollabaratorStatus CollabaratorStatus { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public int TransactionId { get; set; }
        public double Cost { get; set; }
    }
}
