using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class DataRegisterUser
    {
        [DataMember(Name = "UserName")]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int PhoneNumber { get; set; }

        [DataMember]
        public int CreditCardNumber { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }

}
