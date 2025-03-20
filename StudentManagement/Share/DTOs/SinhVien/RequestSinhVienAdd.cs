using StudentManagement.gRPC.DTOs.Lop;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.SinhVien
{
    [DataContract]
    public class RequestSinhVienAdd
    {
        [DataMember(Order = 1)]
        public int MaSV { get; set; }

        [DataMember(Order = 2)]
        public string TenSV { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public DateTime? NgaySinh { get; set; }

        [DataMember(Order = 4)]
        public string DiaChi { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        public int MaLop { get; set; }

        [DataMember(Order = 6)]
        public LopHoc LopHoc { get; set; } = new LopHoc();
    }
}
