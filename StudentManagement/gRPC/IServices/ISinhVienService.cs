using Google.Protobuf.WellKnownTypes;
using StudentManagement.gRPC.DTOs.SinhVien;
using System.ServiceModel;


namespace StudentManagement.gRPC.IServices
{
    [ServiceContract]
    public interface ISinhVienService
    {
        [OperationContract]
        Task<SinhVienListResponse> GetListSinhVienAsync();

        [OperationContract]
        Task<bool> AddSinhVienAsync(RequestSinhVienAdd request);

        [OperationContract]
        Task<bool> UpdateSinhVienAsync(SinhVienResponse request);

        [OperationContract]
        Task<bool> DeleteSinhVienAsync(RequestSinhVien request);

        [OperationContract]
        Task<SinhVienListResponse> SortSinhVienListByNameAsync();

        [OperationContract]
        Task<SinhVienResponse> SearchBySinhVienIdAsync(RequestSinhVien request);
    }
}
