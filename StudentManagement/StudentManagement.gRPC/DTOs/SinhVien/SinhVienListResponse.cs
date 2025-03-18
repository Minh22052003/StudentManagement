using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.Student
{
    [DataContract]
    public class SinhVienListResponse
    {
        [DataMember(Order = 1)]
        public List<SinhVienResponse> SinhViens { get; set; } = new List<SinhVienResponse>();
    }
}
