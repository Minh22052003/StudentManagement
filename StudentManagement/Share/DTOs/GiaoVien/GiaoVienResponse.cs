using System.Runtime.Serialization;

namespace Share.DTOs.GiaoVien
{
    [DataContract]
    public class GiaoVienResponse
    {
        [DataMember(Order = 1)]
        public int MaGV { get; set; }

        [DataMember(Order = 2)]
        public string TenGV { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        public string NgaySinh { get; set; } = string.Empty;
    }
}
