using System.Runtime.Serialization;

namespace Share.DTOs.GiaoVien
{
    [DataContract]
    public class RequestGiaoVien
    {
        [DataMember(Order = 1)]
        public int MaGV { get; set; }
    }
}
