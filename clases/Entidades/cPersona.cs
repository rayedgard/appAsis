using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.Entidades
{
    public class cPersona
    {
        public virtual int id { get; set; }
        public virtual int dni { get; set; }
        public virtual string nombre { get; set; }
        public virtual string paterno { get; set; }
        public virtual string materno { get; set; }
        public virtual char sexo { get; set; }
        public virtual string ocupacion { get; set; }
        public virtual DateTime nacimiento { get; set; }
        public virtual string direccion { get; set; }
        public virtual string telefono { get; set; }
        public virtual string email { get; set; }
        public virtual string foto { get; set; }/*deberia de ser object debido a que contendra datos de tipo binario*/


    }
}
