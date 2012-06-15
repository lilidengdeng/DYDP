using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace DYDP.Data
{
    public class NHibernateHelper : IDisposable
    {
        public static ISessionFactory _sessionFactory;

        private static ISessionFactory GetSessionFactory()
        {
            return (new Configuration()).Configure().BuildSessionFactory();
        }

        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = GetSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }


        public void Dispose()
        {
            _sessionFactory.Dispose();
        }
    }
}
