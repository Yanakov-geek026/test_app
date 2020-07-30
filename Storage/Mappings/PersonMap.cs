using Domain.Enum;
using Domain.Persons;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("persons");

            Id(i => i.Id, "id");

            Map(u => u.FirstName, "first_name");
            Map(u => u.LastName, "last_name");
            Map(u => u.Sex, "sex").CustomType<SexType>();

            Map(d => d.Deleted, "is_deleted").Not.Nullable();


        }
    }
}
