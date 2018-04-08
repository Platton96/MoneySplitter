﻿using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class DataAddFriend
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember (Name="Id")]
        public int IdFriend { get; set; }
    }
}
