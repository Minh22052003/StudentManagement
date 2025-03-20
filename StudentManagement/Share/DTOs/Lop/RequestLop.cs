using System.Runtime.Serialization;

namespace Share.DTOs.Lop
{
    [DataContract]
    public class RequestLop
    {
        [DataMember(Order = 1)]
        public int MaLop { get; set; }
    }
}
