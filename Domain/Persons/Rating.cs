using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class Rating : PersistentObject
    {
        public virtual Person Person { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual int Value { get; set; }
    }
}
