using Share.DTOs.Lop;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Share.DTOs.SinhVien
{
    [DataContract]
    public class RequestSinhVienAdd
    {
        [DataMember(Order = 1)]
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        public int MaSV { get; set; }

        [DataMember(Order = 2)]
        [Required(ErrorMessage = "Tên sinh viên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sinh viên không vượt quá 100 ký tự")]
        public string TenSV { get; set; } = string.Empty;

        [DataMember(Order = 3)]
        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [DataMember(Order = 4)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(200, ErrorMessage = "Địa chỉ không vượt quá 200 ký tự")]
        public string DiaChi { get; set; } = string.Empty;

        [DataMember(Order = 5)]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn lớp học hợp lệ")]
        public int MaLop { get; set; }

        [DataMember(Order = 6)]
        public LopResponse LopResponse { get; set; } = new LopResponse();
    }
}
