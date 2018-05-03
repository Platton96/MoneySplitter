using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class AddTransactionData
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember(Name = "Coast")]
        public double Cost { get; set; }

        [DataMember]
        public IEnumerable<int> CollaboratorsIds { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime DeadlineDate { get; set; }

        [DataMember]
        public string ImageBase64String { get; set; }
    }
}
