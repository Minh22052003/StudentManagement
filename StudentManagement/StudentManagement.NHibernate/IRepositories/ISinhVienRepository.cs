
using StudentManagement.NHibernate.Models;

namespace StudentManagement.NHibernate.IRepositories
{
    public interface ISinhVienRepository : IRepository<SinhVien>
    {
        Task<List<SinhVien>> GetSinhVienListAsync();
        Task<List<SinhVien>> AddSinhVienAsync(SinhVien sinhVien);

        Task<List<SinhVien>> GetSinhVienListSortByNameAsync(int pageNumber, int pageSize);
    }
}
