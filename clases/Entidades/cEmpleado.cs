using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cEmpleado
    {

        public virtual int id { get; set; }
        public virtual int dni { get; set; }
        public virtual cAgencia idAgecia { get; set; }
        public virtual cArea idArea { get; set; }
        public virtual cModalidad idModalidad { get; set; }
        public virtual DateTime fechaInicio { get; set; }
        public virtual DateTime fechaFin { get; set; }
    }
}
