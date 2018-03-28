using System.Linq;

namespace MoneySplitter.Models.Models
{
    public class FriendsOfUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IQueryable<User> Friends { get; set; }
    }
}
