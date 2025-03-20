using Share.DTOs.Lop;
using System.Runtime.Serialization;

namespace Share.DTOs.SinhVien
{
    [DataContract]
    public class RequestSinhVienUpdate
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
        public LopResponse LopResponse { get; set; } = new LopResponse();
    }
}
