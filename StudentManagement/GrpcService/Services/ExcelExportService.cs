using ClosedXML.Excel;
using Share.DTOs.Common;
using Share.DTOs.Lop;
using Share.IServices;
using System.Reflection;

namespace GrpcService.Services
{
    public class ExcelExportService : IExcelExportService
    {
        public BoolResponse ExportToExcel(List<LopReponseChart> data, string sheetName = "Sheet1", string fileName = "file.xlsx")
        {
            BoolResponse checkexport = new BoolResponse();
            checkexport.Success = false;
            try
            {
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string filePath = Path.Combine(downloadsPath, fileName);

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    if (data == null || !data.Any())
                    {
                        return checkexport;
                    }

                    PropertyInfo[] properties = typeof(LopReponseChart).GetProperties();

                    for (int col = 0; col < properties.Length; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = properties[col].Name;
                    }

                    for (int row = 0; row < data.Count; row++)
                    {
                        for (int col = 0; col < properties.Length; col++)
                        {
                            var value = properties[col].GetValue(data[row]);
                            worksheet.Cell(row + 2, col + 1).Value = value?.ToString() ?? "";
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }
                checkexport.Success =  File.Exists(filePath);
                return checkexport;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xuất file: " + ex.Message);
                return checkexport;
            }
        }
    }
}
