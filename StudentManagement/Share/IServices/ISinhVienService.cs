using Share.DTOs.Common;
using Share.DTOs.SinhVien;
using System.ServiceModel;


namespace Share.IServices
{
    [ServiceContract]
    public interface ISinhVienService
    {
        [OperationContract]
        Task<SinhVienListResponse> GetListSinhVienAsync();

        [OperationContract]
        Task<BoolResponse> AddSinhVienAsync(RequestSinhVienAdd request);

        [OperationContract]
        Task<BoolResponse> UpdateSinhVienAsync(SinhVienResponse request);

        [OperationContract]
        Task<BoolResponse> DeleteSinhVienAsync(RequestSinhVien request);

        [OperationContract]
        Task<SinhVienListResponse> SortSinhVienListByNameAsync();

        [OperationContract]
        Task<SinhVienResponse> SearchBySinhVienIdAsync(RequestSinhVien request);
    }
}
