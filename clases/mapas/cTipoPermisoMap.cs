using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cTipoPermisoMap : ClassMap<cTipoPermiso>
    {
        public cTipoPermisoMap()
        {
            Id(c => c.id);
            Map(c => c.nombre);
            Map(c => c.conGoce);
            Map(c => c.detalle);
            Map(c => c.tipo);
            Map(c => c.limite);

            Table("ttipopersiso");
        }

    }
}
