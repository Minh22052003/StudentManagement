using System.Runtime.Serialization;

namespace Share.DTOs.Lop
{
    [DataContract]
    public class LopReponseChart
    {
        [DataMember(Order = 1)]
        public string giaovien { get; set; }

        [DataMember(Order =2)]
        public string tenlop { get; set; }

        [DataMember(Order =3)]
        public int sohocsinh { get; set; }
    }
}
