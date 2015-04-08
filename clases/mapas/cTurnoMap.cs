using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cTurnoMap : ClassMap<cTurno>
    {
        public cTurnoMap()
        {
            Id(c => c.id);
            Map(c => c.nombre);
            Map(c => c.idSubTurno);
            Map(c => c.horaInicio);
            Map(c => c.horaFin);
            Map(c => c.detalle);
            Map(c => c.nomenclatura);

            Table("tturno");
        }
    }
}
