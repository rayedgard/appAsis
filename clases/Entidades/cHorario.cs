using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cHorario
    {
        public virtual int id { get; set; }
        public virtual string nombre { get; set; }
        public virtual string detalle { get; set; }
        public virtual int periodo { get; set; }

        public virtual IList<cTurno> idTurno { get; set; }

        public cHorario()
        {
            idTurno = new List<cTurno>();
        }

    }
}
