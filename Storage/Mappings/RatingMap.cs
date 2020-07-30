using Domain.Persons;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class RatingMap : ClassMap<Rating>
    {
        public RatingMap()
        {
            Table("rating");

            Id(id => id.Id, "id");

            Map(u => u.Value, "value");

            References(r => r.Person, "id_person");
            References(r => r.Subject, "id_subject");

            Map(d => d.Deleted, "is_deleted").Not.Nullable();

        }
    }
}
