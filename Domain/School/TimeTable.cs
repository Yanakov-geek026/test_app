using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.School
{
    public class TimeTable : PersistentObject
    {
        public virtual string NameWeek { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual NumberLesson NumberLesson { get; set; }
    }
}
