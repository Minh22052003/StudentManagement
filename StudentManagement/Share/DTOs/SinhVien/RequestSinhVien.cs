using System.Runtime.Serialization;

namespace Share.DTOs.SinhVien
{
    [DataContract]
    public class RequestSinhVien
    {
        [DataMember(Order = 1)]
        public int MaSV { get; set; }
    }
}
