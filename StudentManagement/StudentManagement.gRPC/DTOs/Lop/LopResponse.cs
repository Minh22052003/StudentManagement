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
        [DataMember]
        public int MaLop { get; set; }

        [DataMember]
        public string TenLop { get; set; }

        [DataMember]
        public string MonHoc { get; set; }

        [DataMember]
        public int? MaGV { get; set; }

        [DataMember]
        public GiaoVienResponse GiaoVienResponse { get; set; } = new GiaoVienResponse();

    }
}
