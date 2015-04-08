using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    public interface Iabm<T>
    {
        void insertar(T entidade);
        void modificar(T entidade);
        void eliminar(T entidade);
        T retornarPorId(int id);
        IList<T> consultar();
      
    }
}
