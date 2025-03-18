using NHibernate;
using StudentManagement.NHibernate.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.NHibernate.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public List<T> GetAll()
        {
            return _session.Query<T>().ToList();
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public void Add(T entity)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(entity);
            transaction.Commit();
        }

        public void Update(T entity)
        {
            using var transaction = _session.BeginTransaction();
            _session.Update(entity);
            transaction.Commit();
        }

        public void Delete(T entity)
        {
            using var transaction = _session.BeginTransaction();
            _session.Delete(entity);
            transaction.Commit();
        }
    }
}
