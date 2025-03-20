using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Share.IServices;

namespace StudentManagement.Pages
{
    public partial class SinhVienManagement : ComponentBase
    {
        private Share.DTOs.SinhVien.SinhVienListResponse? sinhviens = new();
        private Share.DTOs.SinhVien.RequestSinhVienAdd newStudent = new();
        private Share.DTOs.SinhVien.SinhVienResponse sinhVienEdit = new();
        private Share.DTOs.SinhVien.SinhVienResponse sinhVienDelete = new();
        private Share.DTOs.Lop.LopListResponse classes = new();
        private bool showAddModal = false;
        private bool showEditModal = false;
        private bool showDeleteModal = false;
        private string searchMaSV = "";

        [Inject]
        ISinhVienService SinhVienService { get; set; }

        [Inject]
        ILopHocService LopHocService { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadSinhViensAsync();
            await LoadLopHocsAsync();
        }

        // default
        private async Task LoadSinhViensAsync()
        {
            sinhviens = await SinhVienService.GetListSinhVienAsync();
        }

        // sort by name
        private async Task LoadSinhViensSortByNameAsync()
        {
            sinhviens = await SinhVienService.SortSinhVienListByNameAsync();
        }

        // load item class in add and update form
        private async Task LoadLopHocsAsync()
        {
            classes = await LopHocService.GetListLopAsync();
        }

        // add
        private void ShowAddForm()
        {
            newStudent = new Share.DTOs.SinhVien.RequestSinhVienAdd();
            showAddModal = true;
        }
        private async Task AddSinhVien()
        {
            if (string.IsNullOrWhiteSpace(newStudent.TenSV) ||
            newStudent.NgaySinh == default ||
            string.IsNullOrWhiteSpace(newStudent.DiaChi))
            {
                await JS.InvokeVoidAsync("alert", "Vui lòng nhập đầy đủ thông tin sinh viên!");
                return;
            }
            var response = await SinhVienService.AddSinhVienAsync(newStudent);
            if (response.Success == true)
            {
                showAddModal = false;
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
            showAddModal = false;
        }

        // edit
        private async Task ShowEditForm(int masv)
        {
            var requestsv = new Share.DTOs.SinhVien.RequestSinhVien { MaSV = masv };
            sinhVienEdit = await SinhVienService.SearchBySinhVienIdAsync(requestsv);
            showEditModal = true;
        }
        private async Task UpdateSinhVien()
        {
            if (string.IsNullOrWhiteSpace(sinhVienEdit.TenSV) ||
            sinhVienEdit.NgaySinh == default ||
            string.IsNullOrWhiteSpace(sinhVienEdit.DiaChi))
            {
                await JS.InvokeVoidAsync("alert", "Vui lòng nhập đầy đủ thông tin sinh viên!");
                return;
            }
            var response = await SinhVienService.UpdateSinhVienAsync(sinhVienEdit);
            if (response.Success == true)
            {
                showAddModal = false;
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
            showEditModal = false;
        }

        // delete
        private async Task ShowDeleteForm(int masv)
        {
            var requestsv = new Share.DTOs.SinhVien.RequestSinhVien { MaSV = masv };
            sinhVienDelete = await SinhVienService.SearchBySinhVienIdAsync(requestsv);
            showDeleteModal = true;
        }
        private async Task DeleteSinhVien()
        {
            var requestsv = new Share.DTOs.SinhVien.RequestSinhVien { MaSV = sinhVienDelete.MaSV };
            var response = await SinhVienService.DeleteSinhVienAsync(requestsv);
            if (response.Success == true)
            {
                showAddModal = false;
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
            showDeleteModal = false;
        }

        //search
        private async Task SearchStudent()
        {
            if (!string.IsNullOrWhiteSpace(searchMaSV))
            {
                var svrequest = new Share.DTOs.SinhVien.RequestSinhVien { MaSV = int.Parse(searchMaSV) };

                var sinhvien = await SinhVienService.SearchBySinhVienIdAsync(svrequest);
                if (sinhvien == null)
                {
                    await JS.InvokeVoidAsync("alert", "Không tìm thấy sinh viên!");
                    return;
                }

                sinhviens.SinhViens.Clear();
                sinhviens.SinhViens.Add(sinhvien);

            }
            else
            {
                await LoadSinhViensAsync();
            }
        }
    }
}
