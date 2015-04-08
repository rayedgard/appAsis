using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cVacaciones
    {
        public virtual int id { get; set; }
        public virtual int dni { get; set; }
        public virtual int nroVacaciones { get; set; }
        public virtual int vacAsignado { get; set; }
        public virtual string periodo { get; set; }
    }
}
