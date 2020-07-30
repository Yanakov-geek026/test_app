using Domain.School;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class LessonMap : ClassMap<Lesson>
    {
        public LessonMap()
        {
            Table("lesson");

            Id(id => id.Id, "id");

            Map(u => u.Cabinet, "cabiten");            

            References(r => r.Subject, "id_subject");

            //HasMany(x => x.Person).Inverse().Cascade.All().KeyColumn("id_lesson");
            
            Map(d => d.Deleted, "is_deleted").Not.Nullable();
        }        
    }
}
