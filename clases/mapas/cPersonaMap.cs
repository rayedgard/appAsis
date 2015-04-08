using FluentNHibernate.Mapping;
using clases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases.mapas
{
    public class cPersonaMap : ClassMap<cPersona>
    {
        public cPersonaMap()
        {
            Id(c => c.id);
            Map(c => c.dni);
            Map(c => c.nombre);
            Map(c => c.paterno);
            Map(c => c.materno);
            Map(c => c.sexo);
            Map(c => c.ocupacion);
            Map(c => c.nacimiento);
            Map(c => c.direccion);
            Map(c => c.telefono);
            Map(c => c.email);
            Map(c => c.foto);

            Table("tpersona");
        }
    }
}
