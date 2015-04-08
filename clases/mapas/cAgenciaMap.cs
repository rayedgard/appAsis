using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cAgenciaMap : ClassMap<cAgencia>
    {
        public cAgenciaMap()
        {
            Id(c => c.id);
            Map(c => c.nombre);
            Map(c => c.direccion);
            Map(c => c.telefono);

            Table("tagencia");

        }

    }
}
