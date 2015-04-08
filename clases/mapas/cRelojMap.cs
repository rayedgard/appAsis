using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cRelojMap : ClassMap<cReloj>
    {
        public cRelojMap()
        {
            Id(c => c.id);
            Map(c => c.ipreloj);
            Map(c => c.nombre);

            Table("treloj");

        }
    }
}
