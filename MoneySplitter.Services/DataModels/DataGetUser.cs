using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class DataGetUser
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Token { get; set; }
    }
}