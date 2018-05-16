using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class UserData
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
        public long PhoneNumber { get; set; }

        [DataMember]
        public long CreditCardNumber { get; set; }

        [DataMember]
        public double Ballance { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string BackgroundImageUrl { get; set; }

        public IEnumerable<int> Friends { get; set; }
    }
}
