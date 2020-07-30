using Domain.School;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class NumberLessonMap : ClassMap<NumberLesson>
    {
        public NumberLessonMap()
        {
            Table("number_lesson");

            Id(id => id.Id, "id");

            Map(u => u.Number, "number");
            Map(u => u.TimeStart, "time_start");
            Map(u => u.TimeEnd, "time_end");

            Map(d => d.Deleted, "is_deleted").Not.Nullable();
        }
    }
}
