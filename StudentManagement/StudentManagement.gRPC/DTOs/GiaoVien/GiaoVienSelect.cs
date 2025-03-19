﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.DTOs.GiaoVien
{
    [DataContract]
    public class GiaoVienSelect
    {
        [DataMember(Order = 1)]
        public int MaGV { get; set; }

        [DataMember(Order = 2)]
        public string TenGV { get; set; } = string.Empty;
    }
}
