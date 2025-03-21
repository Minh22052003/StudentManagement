using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.DTOs.SinhVien;
using Share.DTOs.Lop;
using Share.IServices;
using Share.DTOs.Common;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.TableModels;
using System.ServiceModel.Channels;
using System;

namespace StudentManagement.Pages
{
    public partial class SinhVienManagement : ComponentBase
    {
        [Inject]
        ISinhVienService SinhVienService { get; set; } = default!;

        [Inject]
        ILopHocService LopHocService { get; set; } = default!;

        [Inject]
        IMessageService _message { get; set; } = default!;

        string searchMaSV = "";

        int pageIndex = 1;
        int pageSize = 10;
        int totalCount = 0;
        int MaSvDelete = 0;

        bool checksort = false;
        bool visibleAdd = false;
        bool visibleEdit = false;
        bool visibleDelete = false;

        List<SinhVienResponse> sinhviens = new();
        RequestSinhVienAdd newStudent = new();
        SinhVienResponse sinhVienEdit = new();
        LopListResponse classes = new();
        List<LopResponse> lopList = new();


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
            pageIndex = queryModel.PageIndex;
            pageSize = queryModel.PageSize;
            await LoadSinhViensAsync();
        }

        //Change SinhVien Sort
        async Task OnSortSinhVien()
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

        //search
        private async Task SearchStudent()
        {
            await LoadSinhViensAsync();
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
            if (newStudent.MaSV == 0 || newStudent.TenSV == "" || newStudent.NgaySinh == null || newStudent.DiaChi == "")
            {
                return;
            }
            var response = await SinhVienService.AddSinhVienAsync(newStudent);
            if (response.Success == true)
            {
                CloseAddForm();
                await _message.Success("Thêm sinh viên thành công!");
                await LoadSinhViensAsync();
            }
            else
            {
                await _message.Error("Thêm sinh viên thất bại!");
            }
        }

        private void CloseAddForm()
        {
            this.visibleAdd = false;
            newStudent = new RequestSinhVienAdd();
        }

        #endregion

        // edit
        #region edit Sinh Vien
        private async Task ShowEditForm(SinhVienResponse rowEdit)
        {
            sinhVienEdit = await SinhVienService.GetSinhVienByIDAsync(rowEdit.MaSV.ToString());
            visibleEdit = true;
        }
        private async Task acceptUpdateSinhVien()
        {
            if(sinhVienEdit.TenSV == "" || sinhVienEdit.NgaySinh == null || sinhVienEdit.DiaChi == "")
            {
                return;
            }
            var response = await SinhVienService.UpdateSinhVienAsync(sinhVienEdit);
            if (response.Success == true)
            {
                await LoadSinhViensAsync();
                await _message.Success("Chỉnh sửa sinh viên thành công!");
                CloseEditForm();
            }
            else
            {
                await _message.Error("Chỉnh sửa sinh viên thất bại!");
            }
        }
        private void CloseEditForm()
        {
            visibleEdit = false;
            sinhVienEdit = new SinhVienResponse();
        }

        #endregion

        // delete
        #region delete Sinh Vien
        private void ShowDeleteForm(SinhVienResponse rowEdit)
        {
            MaSvDelete = rowEdit.MaSV;
            visibleDelete = true;
        }
        private async Task acceptDeleteSinhVien()
        {
            var response = await SinhVienService.DeleteSinhVienAsync(MaSvDelete.ToString());
            if (response.Success == true)
            {
                await LoadSinhViensAsync();
                await _message.Success("Xóa sinh viên thành công!");
                CloseDeleteForm();
            }
            else
            {
                await _message.Error("Xóa sinh viên thất bại!");
            }
        }
        private void CloseDeleteForm()
        {
            visibleDelete = false;
        }

        #endregion


        
    }
}
