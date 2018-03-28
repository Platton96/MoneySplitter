﻿using System;

namespace MoneySplitter.Models.Entities
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public UserModel Debtor { get; set; }
        public UserModel Borrower { get; set; }
        public double AmountOfMoney { get; set; }
        public string NameTransaction { get; set; }
        public DateTime DateTransaction { get; set; }
        public bool IsActiveTransaction { get; set; }
    }
}
