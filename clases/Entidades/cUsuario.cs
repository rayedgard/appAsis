using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cUsuario
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual string pass { get; set; }
        public virtual string correo { get; set; }
        public virtual string privilegio { get; set; }
        public virtual cArea idArea { get; set; }
     }
}
