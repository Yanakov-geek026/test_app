using Domain.School;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class TimeTableMap : ClassMap<TimeTable>
    {
        public TimeTableMap()
        {
            Table("time_table");

            Id(id => id.Id, "id");

            Map(u => u.NameWeek, "name_week");

            References(r => r.Lesson, "lesson_id");
            References(r => r.NumberLesson, "number_lesson_id");

            Map(u => u.Deleted, "is_deleted").Not.Nullable();
        }
    }
}
