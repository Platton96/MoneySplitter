﻿using System;
using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class AddTransactionModel
    {
        public double Cost { get; set; }
        public IEnumerable<int> CollaboratorsIds { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string ImageBase64String { get; set; }

    }
}