﻿using System.Runtime.Serialization;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class DataRemoveFriend
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember(Name = "Id")]
        public int FriendId { get; set; }
    }
}
