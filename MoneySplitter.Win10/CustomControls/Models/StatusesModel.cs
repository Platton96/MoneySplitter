using MoneySplitter.Models;
using System;

namespace MoneySplitter.Win10.CustomControls.Models
{
    public class StatusesModel
    {
        public TransactionStatus TransactionStatus { get; set; }
        public CollabaratorStatus CollabaratorStatus { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as StatusesModel;
            return TransactionStatus == other.TransactionStatus &&
                 CollabaratorStatus == other.CollabaratorStatus;
        }

    }
}   
