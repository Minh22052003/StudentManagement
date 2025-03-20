using System.Runtime.Serialization;

namespace Share.DTOs.SinhVien
{
    [DataContract]
    public class SinhVienListResponse
    {
        [DataMember(Order = 1)]
        public List<SinhVienResponse> SinhViens { get; set; } = new List<SinhVienResponse>();
    }
}
