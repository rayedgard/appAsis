using NHibernate;
using NHibernate.Engine.Query;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    public class RepositorioIn<T>: Iabm<T> where T:class
    {

        public void insertar(T entidade)
        {
            using (ISession session = FluentiSessionFactori.OpenSession())
            {
                using (ITransaction transaccion = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaccion.WasCommitted)
                        {
                            transaccion.Rollback();
                        }
                        throw new Exception("Error al Insertar la entidad " + ex.Message);
                    }


                }
            }
        }

        public void modificar(T entidade)
        {
            using (ISession session = FluentiSessionFactori.OpenSession())
            {
                using (ITransaction transaccion = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaccion.WasCommitted)
                        {
                            transaccion.Rollback();
                        }
                        throw new Exception("Error al Modificar la entidad " + ex.Message);
                    }


                }
            }
        }

        public void eliminar(T entidade)
        {
            using (ISession session = FluentiSessionFactori.OpenSession())
            {
                using (ITransaction transaccion = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaccion.WasCommitted)
                        {
                            transaccion.Rollback();
                        }
                        throw new Exception("Error al Eliminar la entidad " + ex.Message);
                    }


                }
            }
        }

        public T retornarPorId(int id)
        {
            using (ISession session = FluentiSessionFactori.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> consultar()
        {
            using (ISession session = FluentiSessionFactori.OpenSession())
            {
                return (from e in session.Query<T>() select e).ToList();
            }
        }


        

    }
}
