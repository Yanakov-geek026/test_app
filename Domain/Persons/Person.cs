using Domain.Enum;
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
    }
}
