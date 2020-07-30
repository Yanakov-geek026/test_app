using Domain.Persons;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Table("subject");

            Id(id => id.Id, "id");

            Map(u => u.Name, "name");

            Map(d => d.Deleted, "is_deleted").Not.Nullable();
        }
    }
}
