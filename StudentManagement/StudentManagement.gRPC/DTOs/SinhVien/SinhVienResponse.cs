using StudentManagement.gRPC.DTOs.Lop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.Student
{
    [DataContract]
    public class SinhVienResponse
    {
        [DataMember(Order = 1)]
        public int MaSV { get; set; }

        [DataMember(Order = 2)]
        public string TenSV { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string NgaySinh { get; set; } = string.Empty;

        [DataMember(Order = 4)]
        public string DiaChi { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public int? MaLop { get; set; }

        [DataMember(Order = 6)]
        public LopResponse LopResponse { get; set; } = new LopResponse();
    }
}
