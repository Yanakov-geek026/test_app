using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.School
{
    public class NumberLesson : PersistentObject
    {
        public virtual int Number { get; set; }
        public virtual string TimeStart { get; set; }
        public virtual string TimeEnd { get; set; }
    }
}
