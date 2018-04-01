using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySplitter.Infrastructure
{
    public interface IUserModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        int PhoneNumber { get; set; }
        int CreditCardNumber { get; set; }
        double Ballance { get; set; }
    }
}
