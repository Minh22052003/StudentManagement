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
    public class LopHocRepository : Repository<LopHoc>, ILopHocRepository
    {
        private readonly ISession _session;
        public LopHocRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public async Task<List<LopHoc>> GetLopHocListAsync()
        {
            var lophocs = new List<LopHoc>();
            try
            {
                lophocs = await _session.Query<LopHoc>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.ToString());
                throw;
            }
            return lophocs;
        }
    }
}
