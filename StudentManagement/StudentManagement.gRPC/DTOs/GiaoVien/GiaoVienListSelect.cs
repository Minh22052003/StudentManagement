using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.GiaoVien
{
    [DataContract]
    public class GiaoVienListSelect
    {
        [DataMember(Order = 1)]
        public List<GiaoVienSelect> GiaoVienSelects { get; set; } = new List<GiaoVienSelect>();
    }
}
