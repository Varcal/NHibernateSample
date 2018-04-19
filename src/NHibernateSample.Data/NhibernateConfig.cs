using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace NHibernateSample.Data
{
    public class NhibernateConfig
    {
        public static Configuration Initialize()
        {
            var config = new Configuration();

            config.Configure("NHibernate.config");
            //config.AddAssembly(Assembly.GetExecutingAssembly());

            return config;
        }

        public static ISessionFactory GetSessionFactory()
        {
            return Initialize().BuildSessionFactory();
        }
    }
}
