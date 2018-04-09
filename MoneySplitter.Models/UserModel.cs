using System.Collections.Generic;

namespace MoneySplitter.Models
{

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int CreditCardNumber { get; set; }
        public double Ballance { get; set; }
        public IEnumerable<UserModel> Friends { get; set; }
    }
}
