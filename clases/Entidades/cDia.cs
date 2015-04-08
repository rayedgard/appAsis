using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cDia
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual DateTime fecha { get; set; }
        public virtual string detalle { get; set; }
    }
}
