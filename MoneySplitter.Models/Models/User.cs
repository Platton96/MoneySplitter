using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySplitter.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public int NumerCard { get; set; }
        public double AmountOFMoney { get; set; }
    }
}
