using Share.DTOs.Common;
using Share.DTOs.GiaoVien;
using Share.DTOs.Lop;
using System.ServiceModel;

namespace Share.IServices
{
    [ServiceContract]
    public interface IExcelExportService
    {
        [OperationContract]
        Task<BoolResponse> ExportToExcelGiaoVienAsync(RequestGiaoVien data);
    }
}
