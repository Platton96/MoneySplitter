using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneySplitter.Models.Models
{
    public class FriendsOfUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IQueryable<User> Friends { get; set; }
    }
}
