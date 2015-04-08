using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cAsistencia
    {
        public virtual int id { get; set; }
        public virtual int dni { get; set; }
        public virtual DateTime fecha { get; set; }
        public virtual cHorario idHorario { get; set; }
        public virtual string detalle { get; set; }
    }
}
