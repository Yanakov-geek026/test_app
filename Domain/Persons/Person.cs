//using Domain.DB;
using Domain.Enum;
using Domain.School;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class Person : PersistentObject
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }        
        public virtual SexType Sex { get; set; }  
        //public virtual IList<Lesson> Lessons { get; set; }
    }
}
