using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cAgencia
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual string direccion { get; set; }
        public virtual string telefono { get; set; }
    }
}
