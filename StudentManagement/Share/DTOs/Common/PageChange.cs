using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs.Common
{
    [DataContract]
    public class PageChange
    {
        [DataMember(Order = 1)]
        public int PageIndex { get; set; }

        [DataMember(Order = 2)]
        public int PageSize { get; set; }
    }
}
