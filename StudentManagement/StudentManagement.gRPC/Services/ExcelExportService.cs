using ClosedXML.Excel;
using StudentManagement.gRPC.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.Services
{
    public class ExcelExportService : IExcelExportService
    {
        public bool ExportToExcel<T>(List<T> data, string sheetName = "Sheet1", string fileName = "file.xlsx") where T : class
        {
            try
            {
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string filePath = Path.Combine(downloadsPath, fileName);

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    if (data == null || !data.Any())
                    {
                        return false;
                    }

                    PropertyInfo[] properties = typeof(T).GetProperties();

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

                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xuất file: " + ex.Message);
                return false;
            }
        }
    }
}
