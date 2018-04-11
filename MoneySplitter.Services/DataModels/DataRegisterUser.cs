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
        public long PhoneNumber { get; set; }

        [DataMember]
        public long CreditCardNumber { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string ImageBase64String { get; set; }

        [DataMember]
        public string BackgroundImageBase64String { get; set; }
    }

}
