using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace CTTPB.MESCDP.Infrastructure.Data
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISession _session;
        public static string _connectionString { get; set; }


        private static readonly object Padlock = new object();

        public static ISessionFactory SessionFactory
        {
            get
            {
                lock (Padlock)
                {
                    if (_sessionFactory == null) _sessionFactory = CreateSessionFactory();

                    return _sessionFactory;
                }
            }
        }

        public static ISession Session
        {
            get
            {
                if (!CurrentSessionContext.HasBind(SessionFactory))
                    CurrentSessionContext.Bind(SessionFactory.OpenSession());

                _session = SessionFactory.GetCurrentSession();
                return _session;
            }
        }

        public static string ConnectionString
        {
            get
            {
                NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
                return cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString);
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            //return Fluently.Configure()
            //    //which database
            //    .Database(MsSqlConfiguration.MsSql2008
            //        .ConnectionString(ConnectionString).ShowSql()
            //    )
            //    //2nd level cache
            //    .Cache(
            //        c => c.UseQueryCache()
            //            .UseSecondLevelCache()
            //            .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
            //    //find/set the mappings
            //    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMapping>())
            //    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
            //    .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "thread_static"))
            //    .BuildSessionFactory();


            var cfg = GetConfiguration();
            return cfg.BuildSessionFactory();
        }

        public static Configuration GetConfiguration()
        {
            var cfg = new Configuration();
            //cfg.Configure().SetProperty("connection.connection_string", _connectionString);
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg;
        }

        public static void UnbindSessionContext()
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
                CurrentSessionContext.Unbind(SessionFactory);
        }
    }
}
