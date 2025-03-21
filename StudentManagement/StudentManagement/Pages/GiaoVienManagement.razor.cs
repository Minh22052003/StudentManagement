using AntDesign;
using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.DTOs.GiaoVien;
using Share.DTOs.Lop;
using Share.IServices;


namespace StudentManagement.Pages
{
    public partial class GiaoVienManagement : ComponentBase
    {
        [Inject]
        private IGiaoVienService _giaoVienService { get; set; } = default!;

        [Inject]
        private ILopHocService _lopHocService { get; set; } = default!;

        [Inject]
        private IExcelExportService _excelExportService { get; set; } = default!;

        [Inject]
        IMessageService _message { get; set; } = default!;

        int _selectedValue;
        int _selectedMaGV;

        bool isExporting = false;

        private List<LopReponseChart> LopReponseCharts = new();
        GiaoVienListSelect GiaoViens = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadListGiaoVien();
            StateHasChanged();
        }

        private async Task LoadListGiaoVien()
        {
            GiaoViens = await _giaoVienService.GetAllGiaoVienAsync();
        }

        private async Task LoadlopReponseCharts(int maGV)
        {
            LopReponseCharts = await _lopHocService.SearchByGiaoVienIdAsync(maGV.ToString());
        }

        ColumnConfig config1 = new ColumnConfig
        {
            XField = "tenlop",
            YField = "sohocsinh"
        };


        private async Task OnSelectedItemChangedHandler(GiaoVienSelect value)
	    {
            _selectedMaGV = value.MaGV;
            await LoadlopReponseCharts(value.MaGV);
            await InvokeAsync(StateHasChanged);
        }

        private async Task ExcelExportAsync()
        {
            if (LopReponseCharts.Count > 0)
            {
                isExporting = true;
                var checkExport =await _excelExportService.ExportToExcelGiaoVienAsync(_selectedMaGV.ToString());
                if(checkExport.Success == false)
                {
                    await _message.Error("Xuất file Excle không thành công!");
                    isExporting = false;
                }
                else
                {
                    await _message.Success("Xuất file Excle thành công!");
                    isExporting = false;
                }
            }
            else
            {
                await _message.Warning("Không có dữ liệu để xuất excel!");
                isExporting = false;
            }
        }

    }
}
