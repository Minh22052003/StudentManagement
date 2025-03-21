using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs.Common
{
    [DataContract]
    public class PageFilterRequest
    {
        [DataMember(Order =1)]
        public PageChange PageChange { get; set; }

        [DataMember(Order = 2)]
        public int? IDSinhVien { get; set; }

        [DataMember(Order = 3)]
        public bool IsSortByNameSinhVien { get; set; }
    }
}
