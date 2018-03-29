using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MoneySplitter.Models
{
    [DataContract]
    public class UserModel
    {
        [JsonProperty]
        [DataMember]
        public int Id { get; set; }
        [JsonProperty]
        [DataMember (Name="UserName")]
        public string Name { get; set; }
        [JsonProperty]
        [DataMember]
        public string Surname { get; set; }
        [JsonProperty]
        [DataMember]
        public string Email { get; set; }
        [JsonProperty]
        [DataMember]
        public string Password { get; set; }
        [JsonProperty]
        [DataMember]
        public int PhoneNumber { get; set; }
        [JsonProperty]
        [DataMember]
        public int CreditCardNumber { get; set; }
        [JsonProperty]
        [DataMember]
        public double Ballance { get; set; }
        public IEnumerable<UserModel> Friends { get; set; }
    }
}
