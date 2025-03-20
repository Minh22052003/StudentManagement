using StudentManagement.gRPC.DTOs.GiaoVien;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.Lop
{
    [DataContract]
    public class LopResponse
    {
        [DataMember(Order = 1)]
        public int MaLop { get; set; }

        [DataMember(Order = 2)]
        public string TenLop { get; set; }

        [DataMember(Order = 3)]
        public string MonHoc { get; set; }

        [DataMember(Order = 4)]
        public int? MaGV { get; set; }

        [DataMember(Order = 5)]
        public GiaoVienResponse GiaoVienResponse { get; set; } = new GiaoVienResponse();

    }
}
