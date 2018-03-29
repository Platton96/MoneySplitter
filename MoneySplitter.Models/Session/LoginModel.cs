using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MoneySplitter.Models.Session
{
    [DataContract]
    public class LoginModel
    {
        [JsonProperty]
        [DataMember]
        public string Email { get; set; }
        [JsonProperty]
        [DataMember]
        public string Password { get; set; }
    }
}
