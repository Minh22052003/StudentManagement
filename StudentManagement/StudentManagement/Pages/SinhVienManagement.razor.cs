using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.DTOs.SinhVien;
using Share.DTOs.Lop;
using Share.IServices;
using Share.DTOs.Common;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.TableModels;

namespace StudentManagement.Pages
{
    public partial class SinhVienManagement : ComponentBase
    {
        List<SinhVienResponse> sinhviens = new();
        RequestSinhVienAdd newStudent = new();
        SinhVienResponse sinhVienEdit = new();
        SinhVienResponse sinhVienDelete = new();
        LopListResponse classes = new();
        List<LopResponse> lopList = new();

        bool checksort = false;
        bool visibleAdd = false;
        bool visibleEdit = false;
        bool visibleDelete = false;

        string searchMaSV = "";
        int pageIndex = 1;
        int pageSize = 10;
        int totalCount = 0;

        IEnumerable<SinhVienResponse> _selectedRows ;


        [Inject]
        ISinhVienService SinhVienService { get; set; }

        [Inject]
        ILopHocService LopHocService { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadSinhViensAsync();
            await LoadListLopsAsync();
        }



        // default
        private async Task LoadSinhViensAsync()
        {
            PageFilterRequest pageFilterRequest = new PageFilterRequest();
            pageFilterRequest.PageChange = new PageChange { PageIndex = pageIndex, PageSize = pageSize };
            pageFilterRequest.IsSortByNameSinhVien = checksort;
            if(!string.IsNullOrWhiteSpace(searchMaSV))
            {
                pageFilterRequest.IDSinhVien = int.Parse(searchMaSV);
            }
            var sinhVienPageResponse = await SinhVienService.GetListSinhVienAsync(pageFilterRequest);
            sinhviens = sinhVienPageResponse.SinhViens;
            totalCount = sinhVienPageResponse.Total;
        }

        // load list lop
        private async Task LoadListLopsAsync()
        {
            classes = await LopHocService.GetListLopAsync();
            lopList = classes.Lops.ToList();
        }


        //Change Table
        async Task OnChange(QueryModel<SinhVienResponse> queryModel)
        {
            pageIndex = queryModel.PageIndex + 1;
            pageSize = queryModel.PageSize;
            await LoadSinhViensAsync();
        }

        //Change SinhVien Sort
        async Task OnChangeSortSinhVien()
        {
            if(checksort == false)
            {
                checksort = true;
                await LoadSinhViensAsync();
            }
            else
            {
                checksort = false;
                await LoadSinhViensAsync();
            }
        }

        // add
        #region add Sinh Vien
        private async Task ShowAddForm()
        {
            await LoadListLopsAsync();
            this.visibleAdd = true;
        }

        private async Task acceptAddSinhVien()
        {
            var response = await SinhVienService.AddSinhVienAsync(newStudent);
            if (response.Success == true)
            {
                CloseAddForm();
                await JS.InvokeVoidAsync("alert", "Thêm sinh viên thành công!");
                await LoadSinhViensAsync();
            }
            else
            {
                await JS.InvokeVoidAsync("alert", "Thêm sinh viên thất bại!");
            }
        }

        private void CloseAddForm()
        {
            this.visibleAdd = false;
        }

        #endregion

        // edit
        #region edit Sinh Vien
        private async Task ShowEditForm(SinhVienResponse rowEdit)
        {
            var requestsv = new RequestSinhVien { MaSV = rowEdit.MaSV };
            sinhVienEdit = await SinhVienService.SearchBySinhVienIdAsync(requestsv);
            visibleEdit = true;
        }
        private async Task acceptUpdateSinhVien()
        {
            
            var response = await SinhVienService.UpdateSinhVienAsync(sinhVienEdit);
            if (response.Success == true)
            {
                await LoadSinhViensAsync();
                await JS.InvokeVoidAsync("alert", "Chỉnh sửa sinh viên thành công!");
                CloseEditForm();
            }
            else
            {
                await JS.InvokeVoidAsync("alert", "Chỉnh sửa sinh viên thất bại!");
            }
        }
        private void CloseEditForm()
        {
            visibleEdit = false;
        }

        #endregion

        // delete
        #region delete Sinh Vien
        private async Task ShowDeleteForm(SinhVienResponse rowEdit)
        {
            var requestsv = new RequestSinhVien { MaSV = rowEdit.MaSV };
            sinhVienDelete = await SinhVienService.SearchBySinhVienIdAsync(requestsv);
            visibleDelete = true;
        }
        private async Task acceptDeleteSinhVien()
        {
            var requestsv = new RequestSinhVien { MaSV = sinhVienDelete.MaSV };
            var response = await SinhVienService.DeleteSinhVienAsync(requestsv);
            if (response.Success == true)
            {
                await LoadSinhViensAsync();
                await JS.InvokeVoidAsync("alert", "Xóa sinh viên thành công!");
                CloseDeleteForm();
            }
            else
            {
                await JS.InvokeVoidAsync("alert", "Xóa sinh viên thất bại!");
            }
        }
        private void CloseDeleteForm()
        {
            visibleDelete = false;
        }

        #endregion

        //search
        private async Task SearchStudent()
        {
            await LoadSinhViensAsync();
        }

        
    }
}
