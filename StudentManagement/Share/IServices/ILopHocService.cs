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
        Task<List<LopReponseChart>> SearchLopHocByGiaoVienIdAsync(string MaGV);
    }
}
