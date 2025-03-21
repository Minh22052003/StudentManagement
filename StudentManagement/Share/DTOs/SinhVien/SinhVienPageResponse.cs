using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs.SinhVien
{
    [DataContract]
    public class SinhVienPageResponse
    {
        [DataMember(Order = 1)]
        public List<SinhVienResponse> SinhViens { get; set; }

        [DataMember(Order = 2)]
        public int Total { get; set; }
    }
}
