
using StudentManagement.NHibernate.Models;

namespace StudentManagement.NHibernate.IRepositories
{
    public interface ISinhVienRepository : IRepository<SinhVien>
    {
        Task<List<SinhVien>> GetSinhVienListAsync();
        Task<SinhVien> AddSinhVienAsync(SinhVien sinhVien);

        Task<SinhVien> UpdateSinhVienAsync(SinhVien sinhVien);

        Task<bool> DeleteSinhVienAsync(SinhVien sinhVien);

        Task<SinhVien> GetSinhVienByIDAsync(int id);

        Task<List<SinhVien>> GetSinhVienListSortByNameAsync();

        Task<List<SinhVien>> GetSinhVienListByLopHocAsync(int MaLop);
    }
}
