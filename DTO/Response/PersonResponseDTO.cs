using Domain.Enum;
using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class PersonResponseDTO
    {
        //public long ID { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public SexType sexType { get; set; }

        public PersonResponseDTO() { }        

        public PersonResponseDTO(Person person)
        {
            if (person == null)
                return;

            //ID = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            sexType = person.Sex;
        }

    }
}
