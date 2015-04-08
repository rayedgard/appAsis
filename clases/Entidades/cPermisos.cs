using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
      public class cPermisos
    {
        public virtual int id{ get; set; }
        public virtual int dni { get; set; }
        public virtual DateTime fecha { get; set; }
        public virtual cTipoPermiso idTipoPermiso { get; set; }
        public virtual string documento { get; set; }
        public virtual string detalle { get; set; }
    }
}

