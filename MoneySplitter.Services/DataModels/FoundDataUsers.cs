using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MoneySplitter.Services.DataModels
{
    [DataContract]
    public class FoundDataUsers
    {
        [DataMember]
        public IEnumerable<DataUser> DataUsers { get; set; }
    }
}
