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
        Task<SinhVienResponse> GetSinhVienByIDAsync(string MaSV);

        [OperationContract]
        Task<BoolResponse> AddSinhVienAsync(RequestSinhVienAdd request);

        [OperationContract]
        Task<BoolResponse> UpdateSinhVienAsync(SinhVienResponse request);

        [OperationContract]
        Task<BoolResponse> DeleteSinhVienAsync(string MaSV);


    }
}
