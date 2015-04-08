using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cTipoPermiso
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual string conGoce { get; set; }
        public virtual string detalle { get; set; }
        public virtual string tipo { get; set; }
        public virtual int limite { get; set; }
    }
}
