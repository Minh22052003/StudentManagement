using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.Lop
{
    [DataContract]
    public class RequestLop
    {
        [DataMember(Order = 1)]
        public int MaLop { get; set; }
    }
}
