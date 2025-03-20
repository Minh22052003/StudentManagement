using Share.DTOs.Common;
using Share.DTOs.Lop;
using System.ServiceModel;

namespace Share.IServices
{
    [ServiceContract]
    public interface IExcelExportService
    {
        [OperationContract]
        BoolResponse ExportToExcel(List<LopReponseChart> data, string sheetName = "Sheet1", string fileName = "file.xlsx");
    }
}
