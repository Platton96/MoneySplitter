using System;
using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class TransactionEventModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatingDate { get; set; }
        public TypeDate TypeDate { get; set; }
        public double SingleCost { get; set; }
        public UserRole UserRole { get; set; }
        public UserRole FriendRole { get; set; }
        public IEnumerable<string> CollaboratorImageUrls { get; set; }
        public int NotVisibilCollabarratorsCount { get; set; }
        public int? FriendId { get; set; }
        public int TransactionId { get; set; }
        public bool IsAllButtonVisibil { get; set; } = true;
        public bool IsGiveButtonVisibil => IsAllButtonVisibil && UserRole == UserRole.IN_BEGIN;
        public bool IsRemindButtonVisibil => IsAllButtonVisibil && UserRole == UserRole.IN_PROGRESS;

        public bool IsAproveButtonVisibil => IsAllButtonVisibil && 
                                             UserRole == UserRole.USER_TRANSACTION && 
                                             FriendRole!=UserRole.UNDEFINED;

        public bool IsSmallRemindButtonVisibil => IsAllButtonVisibil && 
                                                  UserRole == UserRole.USER_TRANSACTION && 
                                                  FriendRole == UserRole.IN_BEGIN;
    }
}
