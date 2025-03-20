using System.Runtime.Serialization;

namespace Share.DTOs.GiaoVien
{
    [DataContract]
    public class GiaoVienListResponse
    {
        [DataMember(Order = 1)]
        public List<GiaoVienResponse> GiaoViens { get; set; } = new List<GiaoVienResponse>();
    }
}
