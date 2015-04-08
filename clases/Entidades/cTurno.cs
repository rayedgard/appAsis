using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cTurno
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual int idSubTurno { get; set; }
        public virtual DateTime horaInicio { get; set; }
        public virtual DateTime horaFin { get; set; }
        public virtual string detalle { get; set; }
        public virtual char nomenclatura { get; set; }
    }
}
