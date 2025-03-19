using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.NHibernate.IRepositories
{
    public interface IGiaoVienRepository
    {
        Task<List<GiaoVien>> GetGiaoVienListAsync();
        Task<GiaoVien> AddGiaoVienAsync(GiaoVien giaoVien);
        Task<GiaoVien> UpdateGiaoVienAsync(GiaoVien giaoVien);
        Task<bool> DeleteGiaoVienAsync(GiaoVien giaoVien);
        Task<GiaoVien> GetGiaoVienByIDAsync(int id);
        Task<List<GiaoVien>> GetGiaoVienListSortByNameAsync();
        Task<List<GiaoVien>> GetGiaoVienListBySinhVienAsync(SinhVien sinhVien);
    }
}
