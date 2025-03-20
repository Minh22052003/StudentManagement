using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs.Common
{
    [DataContract]
    class PageTotalResponse
    {
        [DataMember]
        public int Total { get; set; }
    }
}
