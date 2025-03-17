using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Cfg;
using System;
using ISession = NHibernate.ISession;

namespace StudentManagement.NHibernate.DataAccess
{
    public class NHibernateSessionManager
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        static NHibernateSessionManager()
        {
            _sessionFactory = new Configuration().Configure("Configs/hibernate.cfg.xml").BuildSessionFactory();
        }


        public NHibernateSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public ISession GetCurrentSession()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                throw new InvalidOperationException("No active HTTP context.");
            }

            var currentSession = context.Items[CurrentSessionKey] as ISession;
            if (currentSession == null)
            {
                currentSession = _sessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }
        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
        public void CloseSession()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
            {
                return;
            }

            var currentSession = context.Items[CurrentSessionKey] as ISession;
            if (currentSession != null)
            {
                currentSession.Close();
                context.Items.Remove(CurrentSessionKey);
            }
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}
