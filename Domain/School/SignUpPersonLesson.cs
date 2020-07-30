using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.School
{
    public class SignUpPersonLesson : PersistentObject
    {
        public virtual Lesson Lesson { get; set; }
        public virtual Person Person { get; set; }
    }
}
