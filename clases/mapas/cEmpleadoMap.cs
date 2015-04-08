using clases.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cEmpleadoMap: ClassMap<cEmpleado>
    {
        public cEmpleadoMap()
        {
            Id(c => c.id);
            Map(x => x.dni);
            References(c => c.idAgecia).Column("IDAGENCIA");
            References(c => c.idArea).Column("IDAREA"); 
            References(c => c.idModalidad).Column("IDMODALIDAD");
            Map(c => c.fechaInicio);
            Map(c => c.fechaFin);

            Table("templeado");
        }
    }
}
