using Domain.School;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class SignUpPersonLessonMap : ClassMap<SignUpPersonLesson>
    {
        public SignUpPersonLessonMap()
        {
            Table("sign_up_person_lesson");

            Id(id => id.Id, "id");

            References(r => r.Lesson, "lesson_id");
            References(r => r.Person, "person_id");

            Map(u => u.Deleted, "is_deleted").Not.Nullable();
        }
    }
}
