using System.Collections.Generic;

namespace MoneySplitter.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public int NumberCard { get; set; }
        public double AmountOfMoney { get; set; }
        public IEnumerable<UserModel> Friends { get; set; }
    }
}
