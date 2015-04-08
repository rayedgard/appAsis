using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{

    public class cPermisosMap : ClassMap<cPermisos>
    {
        public cPermisosMap()
        {
            Id(c => c.id);
            Map(c => c.dni);
            Map(c => c.fecha);
            References(c => c.idTipoPermiso).Column("id"); ;
            Map(c => c.documento);
            Map(c => c.detalle);

            Table("tpermisos");
        }
    }
}
