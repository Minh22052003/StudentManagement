using StudentManagement.gRPC.DTOs.SinhVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.Lop
{
    [DataContract]
    public class LopListResponse
    {
        [DataMember(Order = 1)]
        public List<LopResponse> Lops { get; set; } = new List<LopResponse>();
    }
}
