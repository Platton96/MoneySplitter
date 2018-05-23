using System;
using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class TransactionEventModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double SingleCost { get; set; }
        public UserRole UserRole { get; set; }
        public IEnumerable<string> CollaboratorImageUrls { get; set; }
        public int NotVisibilCollabarratorsCount { get; set; }
        public int TransactionId { get; set; }
        public bool IsGiveButtonVisibil => UserRole == UserRole.IN_BEGIN;
        public bool IsRemindButtonVisibil => UserRole == UserRole.IN_PROGRESS;
    }
}
