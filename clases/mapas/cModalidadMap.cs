using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cModalidadMap : ClassMap<cModalidad>
    {
        public cModalidadMap()
        {
            Id(c => c.id);
            Map(c => c.nombre);
            Map(c => c.detalle);

            Table("tmodalidad");
        }
    }
}
