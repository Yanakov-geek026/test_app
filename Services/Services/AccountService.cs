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
    class AccountService : BaseCrudService<Person>, IAccountService
    {
        private IPersonService personService;
        
        public AccountService(IRepository<Person> repository, IPersonService personService) : base(repository)
        {
            this.personService = personService;
        }

        public PersonResponseDTO RegisterPerson(PersonDTO createPerson)
        {
            var person = personService.CreatePerson(createPerson);
            return new PersonResponseDTO(person);
        }
    }
}
