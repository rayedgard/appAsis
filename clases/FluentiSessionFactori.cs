using clases.configuraciones;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    public class FluentiSessionFactori
    {
        
        private static string Cadena = cPublica.ArchivosGlovales.cadena;

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }


        private static void InitializeSessionFactory()
        {
            if(cPublica.ArchivosGlovales.valorInicial=="0")
                _sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(Cadena).ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<mapas.cAreaMap>()).ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true)).BuildSessionFactory();
            else
                _sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(Cadena).ShowSql()).Mappings(C => C.FluentMappings.AddFromAssemblyOf<mapas.cAreaMap>()).BuildSessionFactory();
            
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }








    }
}
