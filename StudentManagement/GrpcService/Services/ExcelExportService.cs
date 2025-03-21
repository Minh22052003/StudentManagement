using ClosedXML.Excel;
using Share.DTOs.Common;
using Share.DTOs.GiaoVien;
using Share.DTOs.Lop;
using Share.IServices;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Models;
using System.Reflection;

namespace GrpcService.Services
{
    public class ExcelExportService : IExcelExportService
    {
        private readonly ILopHocRepository _lopHocRepository;
        public ExcelExportService(ILopHocRepository lopHocRepository)
        {
            _lopHocRepository = lopHocRepository;
        }
        public async Task<BoolResponse> ExportToExcelGiaoVienAsync(string MaGV)
        {
            string sheetName = "Sheet1";
            string fileName = "Data.xlsx";
            int j = 0;
            BoolResponse checkexport = new BoolResponse();
            checkexport.Success = false;
            List<LopHoc> lophocs = await _lopHocRepository.GetLopHocByGiaoVien(int.Parse(MaGV));
            try
            {
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string filePath = Path.Combine(downloadsPath, fileName);

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    if (lophocs == null || !lophocs.Any())
                    {
                        return checkexport;
                    }

                    // Write header row
                    worksheet.Cell(1, 1).Value = "STT";
                    worksheet.Cell(1, 2).Value = "Tên giáo viên";
                    worksheet.Cell(1, 3).Value = "Tên lớp";
                    worksheet.Cell(1, 4).Value = "Tên sinh viên";

                    // Write data rows
                    for (int i = 0; i < lophocs.Count; i++)
                    {
                        var item = lophocs[i];
                        int row = j + 2;
                        foreach (var sv in item.SinhViens)
                        {
                            worksheet.Cell(row, 1).Value = j + 1;
                            worksheet.Cell(row, 2).Value = item.GiaoVien.TenGV ?? "";
                            worksheet.Cell(row, 3).Value = item.TenLop ?? "";
                            worksheet.Cell(row, 4).Value = sv.TenSV ?? "";
                            row++;
                            j++;
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
