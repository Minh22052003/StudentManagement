using Share.DTOs.Common;
using Share.DTOs.SinhVien;
using System.ServiceModel;


namespace Share.IServices
{
    [ServiceContract]
    public interface ISinhVienService
    {
        [OperationContract]
        Task<SinhVienPageResponse> GetListSinhVienAsync(PageFilterRequest pageFilterRequest);

        [OperationContract]
        Task<BoolResponse> AddSinhVienAsync(RequestSinhVienAdd request);

        [OperationContract]
        Task<BoolResponse> UpdateSinhVienAsync(SinhVienResponse request);

        [OperationContract]
        Task<BoolResponse> DeleteSinhVienAsync(RequestSinhVien request);

        [OperationContract]
        Task<List<SinhVienResponse>> SortSinhVienListByNameAsync(PageChange pageChange);

        [OperationContract]
        Task<SinhVienResponse> SearchBySinhVienIdAsync(RequestSinhVien request);

        [OperationContract]
        Task<PageTotalResponse> GetPageTotalAsync();
    }
}
