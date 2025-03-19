using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StudentManagement.gRPC.DTOs.GiaoVien;
using StudentManagement.gRPC.DTOs.Lop;
using StudentManagement.gRPC.IServices;


namespace StudentManagement.Pages
{
    public partial class GiaoVienManagement : ComponentBase
    {
        GiaoVienListSelect giaoviens = new();
        GiaoVienSelect _selectedItem = new();
        int _selectedValue;
        private List<LopReponseChart> lopReponseCharts = new();


        [Inject]
        private IGiaoVienService _giaoVienService { get; set; }

        [Inject]
        private ILopHocService _lopHocService { get; set; }

        [Inject]
        private IExcelExportService _excelExportService { get; set; }

        [Inject]
        private IJSRuntime JS {  get; set; }


        protected override async Task OnInitializedAsync()
        {
            await LoadListGiaoVien();
            StateHasChanged();
        }

        private async Task LoadListGiaoVien()
        {
            giaoviens = await _giaoVienService.GetListGiaoVienSelectAsync();
        }

        private async Task LoadlopReponseCharts(int maGV)
        {
            RequestGiaoVien requestGiaoVien = new RequestGiaoVien
            {
                MaGV = maGV,
            };

            lopReponseCharts = await _lopHocService.SearchByGiaoVienIdAsync(requestGiaoVien);
        }

        ColumnConfig config1 = new ColumnConfig
        {
            XField = "tenlop",
            YField = "sohocsinh"
        };


        private async Task OnSelectedItemChangedHandler(GiaoVienSelect value)
	    {
            
            await LoadlopReponseCharts(value.MaGV);
            await InvokeAsync(StateHasChanged);
        }

        private async Task ExcelExportAsync(List<LopReponseChart> lopReponseCharts)
        {
            if (lopReponseCharts.Count > 0)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"GiaoVien_{timestamp}.xlsx";
                var checkExport = _excelExportService.ExportToExcel(lopReponseCharts, "Main", fileName);
                if(checkExport == false)
                {
                    await JS.InvokeVoidAsync("alert", "Xuất file Excle không thành công!");
                }
                else
                {
                    await JS.InvokeVoidAsync("alert", "Xuất file Excle thành công!");
                }
            }
            else
            {
                await JS.InvokeVoidAsync("alert", "Không có dữ liệu để xuất excel!");
            }
        }

    }
}
