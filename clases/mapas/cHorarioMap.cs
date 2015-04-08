using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    class cHorarioMap : ClassMap<cHorario>
    {
        public cHorarioMap()
        {
            Table("thorario");
            Id(c => c.id);
            Map(c => c.nombre);
            Map(c => c.detalle);
            HasMany<cTurno>(c => c.idTurno).KeyColumn("IDHORARIO");

           
        }
    }
}
