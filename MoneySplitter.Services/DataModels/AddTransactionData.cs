using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class AddTransactionData
    {
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

        [DataMember]
        public DateTime? OngoingDate { get; set; }
    }
}
