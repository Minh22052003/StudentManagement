using System.Runtime.Serialization;

namespace Share.DTOs.Common
{
    [DataContract]
    public class PageChange
    {
        [DataMember(Order = 1)]
        public int PageIndex { get; set; }

        [DataMember(Order = 2)]
        public int PageSize { get; set; }
    }
}
