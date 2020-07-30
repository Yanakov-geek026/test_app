using Domain.Enum;
using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public SexType SexType { get; set; }

        public PersonDTO() { }        

        public PersonDTO(Person person)
        {
            if (person == null)
                return;

            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            SexType = person.Sex;
        }

    }
}
