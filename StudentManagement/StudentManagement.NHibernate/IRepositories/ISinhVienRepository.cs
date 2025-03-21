
using StudentManagement.NHibernate.Models;

namespace StudentManagement.NHibernate.IRepositories
{
    public interface ISinhVienRepository : IRepository<SinhVien>
    {
        Task<List<SinhVien>> GetSinhVienPageAsync(int PageSize, int PageIndex, int? IDSinhVien, bool SortByName);

        Task<bool> AddSinhVienAsync(SinhVien sinhVien);

        Task<bool> UpdateSinhVienAsync(SinhVien sinhVien);

        Task<bool> DeleteSinhVienAsync(int MaSV);

        Task<SinhVien> GetSinhVienByIDAsync(int id);

        Task<int> CountSinhVienAsync();

        Task<bool> CheckSinhVienExistsAsync(int id);
    }
}
