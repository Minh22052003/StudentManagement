using System.Runtime.Serialization;

namespace Share.DTOs.GiaoVien
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
