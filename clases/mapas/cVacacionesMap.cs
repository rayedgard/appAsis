using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cVacacionesMap : ClassMap<cVacaciones>
    {
        public cVacacionesMap()
        {
            Id(c => c.id);
            Map(c => c.dni);
            Map(c => c.nroVacaciones);
            Map(c => c.vacAsignado);
            Map(c => c.periodo);

            Table("tvacaciones");
        }
    }
}
