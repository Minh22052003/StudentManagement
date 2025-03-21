using Share.DTOs.GiaoVien;
using System.ServiceModel;

namespace Share.IServices
{
    [ServiceContract]
    public interface IGiaoVienService
    {
        [OperationContract]
        Task<GiaoVienListSelect> GetAllGiaoVienAsync();

    }
}
