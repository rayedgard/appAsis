using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cAsistenciaMap : ClassMap<cAsistencia>
    {
        public cAsistenciaMap()
        {
            Id(c => c.id);
            Map(c => c.dni);
            Map(c => c.fecha);
            References(c => c.idHorario).Column("id");
            Map(c => c.detalle);

            Table("tasistencia");

        }

    }
}
