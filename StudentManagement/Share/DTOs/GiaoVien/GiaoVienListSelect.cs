using System.Runtime.Serialization;

namespace Share.DTOs.GiaoVien
{
    [DataContract]
    public class GiaoVienListSelect
    {
        [DataMember(Order = 1)]
        public List<GiaoVienSelect> GiaoVienSelects { get; set; } = new List<GiaoVienSelect>();
    }
}
