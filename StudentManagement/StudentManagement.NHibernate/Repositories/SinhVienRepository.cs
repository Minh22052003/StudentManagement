using NHibernate;
using NHibernate.Linq;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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


        public async Task<List<SinhVien>> GetSinhVienPageAsync(int PageSize, int PageIndex, int? IDSinhVien, bool SortByName)
        {
            var sinhviens = new List<SinhVien>();
            try
            {
                if(IDSinhVien != null)
                {
                    sinhviens = await _session.Query<SinhVien>().Where(x => x.MaSV == IDSinhVien).ToListAsync();
                }
                else if (SortByName == true)
                {
                    sinhviens = await _session.Query<SinhVien>().OrderBy(x => x.TenSV).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
                }
                else
                {
                    sinhviens = await _session.Query<SinhVien>().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.ToString());
                throw;
            }
            return sinhviens;
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
        public async Task<bool> AddSinhVienAsync(SinhVien sinhVien)
        {
            try
            {
                if(await CheckSinhVienExistsAsync(sinhVien.MaSV))
                {
                    return false;
                }
                using var transaction = _session.BeginTransaction();
                await _session.SaveAsync(sinhVien);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> UpdateSinhVienAsync(SinhVien sinhVien)
        {
            try
            {
                using var transaction = _session.BeginTransaction();
                await _session.UpdateAsync(sinhVien);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSinhVienAsync(int MaSV)
        {
            try
            {
                using var transaction = _session.BeginTransaction();
                await _session.DeleteAsync(GetSinhVienByIDAsync(MaSV).Result);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<int> CountSinhVienAsync()
        {
            return _session.Query<SinhVien>().CountAsync();
        }

        public Task<bool> CheckSinhVienExistsAsync(int id)
        {
            if (_session.Query<SinhVien>().Any(x => x.MaSV == id))
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
