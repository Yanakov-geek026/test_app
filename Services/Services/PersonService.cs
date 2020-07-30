using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class PersonService : BaseCrudService<Person>, IPersonService
    {
        public PersonService(IRepository<Person> repository) : base(repository) { }        

        public Person CreatePerson(PersonDTO createPerson)
        {
            var person = new Person()
            {
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                Sex = createPerson.SexType
            };

            Create(person);
            return person;
        }
    }
}
