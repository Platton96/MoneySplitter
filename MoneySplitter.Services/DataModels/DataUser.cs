using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class DataUser 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(Name = "UserName")]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int PhoneNumber { get; set; }

        [DataMember]
        public int CreditCardNumber { get; set; }

        [DataMember]
        public double Ballance { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
        
        public IEnumerable<int> Friends { get; set; }
    }
}
