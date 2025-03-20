using Share.DTOs.GiaoVien;
using System.ServiceModel;

namespace Share.IServices
{
    [ServiceContract]
    public interface IGiaoVienService
    {
        [OperationContract]
        Task<GiaoVienListResponse> GetListGiaoVienAsync();

        Task<GiaoVienListSelect> GetListGiaoVienSelectAsync();

        [OperationContract]
        Task<GiaoVienResponse> SearchByGiaoVienIdAsync(RequestGiaoVien requestGiaoVien);
    }
}
