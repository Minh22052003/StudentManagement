using NHibernate;
using NHibernate.Linq;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.NHibernate.Repositories
{
    public class SinhVienRepository : Repository<SinhVien>, ISinhVienRepository
    {
        private readonly ISession _session;
        public SinhVienRepository(ISession session) : base(session)
        {
            _session = session;
        }


        public async Task<List<SinhVien>> GetSinhVienListAsync()
        {
            var sinhviens = new List<SinhVien>();
            try
            {
                sinhviens = await _session.Query<SinhVien>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.ToString());
                throw;
            }
            return sinhviens;
        }
        public async Task<SinhVien> AddSinhVienAsync(SinhVien sinhVien)
        {
            try
            {
                using var transaction = _session.BeginTransaction();

                await _session.SaveAsync(sinhVien);

                await transaction.CommitAsync();

                return sinhVien;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public Task<SinhVien> GetSinhVienByIDAsync(int id)
        {
            try
            {
                return _session.GetAsync<SinhVien>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.ToString());
                throw;
            }
        }

        public async Task<SinhVien> UpdateSinhVienAsync(SinhVien sinhVien)
        {
            try
            {
                using var transaction = _session.BeginTransaction();
                await _session.UpdateAsync(sinhVien);
                await transaction.CommitAsync();
                return sinhVien;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.ToString());
                throw;
            }

        }

        public async Task<bool> DeleteSinhVienAsync(SinhVien sinhVien)
        {
            try
            {
                using var transaction = _session.BeginTransaction();

                await _session.DeleteAsync(sinhVien);

                await transaction.CommitAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<SinhVien>> GetSinhVienListSortByNameAsync()
        {
            return await _session.Query<SinhVien>().OrderBy(x => x.TenSV).ToListAsync();
        }

        public async Task<List<SinhVien>> GetSinhVienListByLopHocAsync(int MaLop)
        {
            return await _session.Query<SinhVien>().Where(x=>x.MaLop == MaLop).ToListAsync();
        }
    }
}
