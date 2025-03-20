using System.Runtime.Serialization;

namespace Share.DTOs.Lop
{
    [DataContract]
    public class LopListResponse
    {
        [DataMember(Order = 1)]
        public List<LopResponse> Lops { get; set; } = new List<LopResponse>();
    }
}
