using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs.Common
{
    [DataContract]
    public class BoolResponse
    {
        [DataMember(Order = 1)]
        public bool Success { get; set; }
    }
}
