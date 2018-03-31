using System.Runtime.Serialization;

namespace MoneySplitter.Models.Session
{
    [DataContract]
    public class RegistrModel
    {
        [DataMember]
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

        

    }
}
