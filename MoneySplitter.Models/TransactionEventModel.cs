﻿using System;
using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class TransactionEventModel
    {
		public TransactionModel RootTransaction { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateType TypeDate { get; set; }
        public double SingleCost { get; set; }
        public UserRole UserRole { get; set; }
        public UserRole FriendRole { get; set; }
        public IEnumerable<string> CollaboratorImageUrls { get; set; }
        public int NotVisibilCollabarratorsCount { get; set; }
        public int? FriendId { get; set; }
        public int TransactionId { get; set; }
        public bool IsForceHide { get; set; } 
        public bool IsGiveButtonVisibil => !IsForceHide && UserRole == UserRole.IN_BEGIN;
        public bool IsRemindButtonVisibil => !IsForceHide && UserRole == UserRole.IN_PROGRESS;

        public bool IsAproveButtonVisibil => !IsForceHide && 
                                             UserRole == UserRole.MY_TRANSACTION && 
                                             FriendRole!=UserRole.UNDEFINED;

        public bool IsSmallRemindButtonVisibil => !IsForceHide && 
                                                  UserRole == UserRole.MY_TRANSACTION && 
                                                  FriendRole == UserRole.IN_BEGIN;
    }
}
