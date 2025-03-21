using Share.DTOs.GiaoVien;
using System.Runtime.Serialization;

namespace Share.DTOs.Lop
{
    [DataContract]
    public class LopResponse
    {
        [DataMember(Order = 1)]
        public int MaLop { get; set; }

        [DataMember(Order = 2)]
        public string? TenLop { get; set; }

        [DataMember(Order = 3)]
        public string? MonHoc { get; set; }

        [DataMember(Order = 4)]
        public int? MaGV { get; set; }

        [DataMember(Order = 5)]
        public GiaoVienResponse GiaoVienResponse { get; set; } = new GiaoVienResponse();

    }
}
