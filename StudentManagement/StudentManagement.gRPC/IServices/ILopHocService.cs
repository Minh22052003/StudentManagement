using StudentManagement.gRPC.DTOs.GiaoVien;
using StudentManagement.gRPC.DTOs.Lop;
using StudentManagement.gRPC.DTOs.SinhVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.IServices
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
