using StudentManagement.gRPC.DTOs.GiaoVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.IServices
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
