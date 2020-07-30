using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class Subject : PersistentObject
    {
        public virtual string Name { get; set; }
    }
}
