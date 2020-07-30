//using Domain.DB;
using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.School
{
    public class Lesson : PersistentObject
    {        
        public virtual int Cabinet { get; set; }
        public virtual Subject Subject { get; set; }
        //public virtual IList<Person> Person { get; set; }
    }
}
