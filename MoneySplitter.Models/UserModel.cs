using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public long CreditCardNumber { get; set; }
        public double Ballance { get; set; }
        public string Token { get; set; }
        public string ImageUrl { get; set; }
        public string BackgroundImageUrl { get; set; }
        public IEnumerable<UserModel> Friends { get; set; }
    }
}
