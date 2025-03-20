using Share.DTOs.GiaoVien;
using Share.DTOs.Lop;
using System.ServiceModel;

namespace Share.IServices
{
    [ServiceContract]
    public interface ILopHocService
    {
        [OperationContract]
        Task<LopListResponse> GetListLopAsync();

        [OperationContract]
        Task<LopResponse> SearchByLopHocIdAsync(RequestLop requestLop);

        [OperationContract]
        Task<List<LopReponseChart>> SearchByGiaoVienIdAsync(RequestGiaoVien requestGiaoVien);
    }
}
