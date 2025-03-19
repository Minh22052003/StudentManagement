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
    public interface IExcelExportService
    {
        [OperationContract]
        bool ExportToExcel<T>(List<T> data, string sheetName = "Sheet1", string fileName = "file.xlsx") where T : class;
    }
}
