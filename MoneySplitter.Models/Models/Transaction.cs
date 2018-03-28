using System;

namespace MoneySplitter.Models.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public User Debtor { get; set; }
        public User Borrower { get; set; }
        public double AmountOfMoney { get; set; }
        public string NameTransaction { get; set; }
        public DateTime DateTransaction { get; set; }
        public bool IsActiveTransaction { get; set; }
    }
}
