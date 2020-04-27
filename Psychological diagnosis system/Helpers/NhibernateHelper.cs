using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//用来映射数据库到实体类 
namespace Psychological_diagnosis_system.Helpers
{
    class NHibernateHelper
    {
        private static ISessionFactory sessionFactory = null;
        private static void InitSessionFactory()
        {
            //FluentConfiguration fConfig = Fluently.Configure();
            //MySQLConfiguration mySQLConfig=MySQLConfiguration.Standard.ConnectionString(db => db.Server("localhost").Database("psychological_diagnosis_system").Username("root").Password("root"));
            //sessionFactory=fConfig.Database(mySQLConfig).Mappings(x => x.FluentMappings.AddFromAssemblyOf<NHibernateHelper>()).BuildSessionFactory();
            //sessionFactory = Fluently.Configure().Database(MySQLConfiguration.Standard
            //    .ConnectionString(db => db.Server("localhost")
            //    .Database("psychological_diagnosis_system").Username("root").Password("root")))
            //    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<NHibernateHelper>()).BuildSessionFactory();//连接MySQL数据库
            sessionFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(db => 
            db.Server("localhost").Database("psychological_diagnosis_system").Username("root").Password("root")))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<NHibernateHelper>()).BuildSessionFactory();
        }
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                    InitSessionFactory();
                return sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();   //打开Session会话
        }
    }
}
