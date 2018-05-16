using System;
using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public UserModel Owner { get; set; }
        public IEnumerable<UserModel> Collaborators { get; set; }
        public IEnumerable<int> FinishedIds { get; set; }
        public IEnumerable<int> InProgressIds { get; set; }
        public double Cost { get; set; }
        public string ImageUrl { get; set; }
        public double SingleCost { get; set; }
    }
}
