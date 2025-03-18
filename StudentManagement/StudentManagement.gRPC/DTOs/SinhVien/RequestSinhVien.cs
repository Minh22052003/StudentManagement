using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.Student
{
    [DataContract]
    public class RequestSinhVien
    {
        [DataMember(Order = 1)]
        public int MaSV { get; set; }
    }
}
