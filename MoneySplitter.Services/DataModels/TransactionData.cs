using MoneySplitter.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class TransactionData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DeadlineDate { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public UserModel Owner { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public IEnumerable<UserData> Collaborators { get; set; }

        [DataMember]
        public IEnumerable<UserData> Finished { get; set; }

        [DataMember]
        public IEnumerable<UserData> InProgress { get; set; }

        [DataMember (Name="Coast")]
        public double Cost { get; set; }

        [DataMember]
        public double SingleCost { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }
}
