using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Storage.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IPersonService : IBaseCrudService<Person>
    {
        Person CreatePerson(PersonDTO createPerson);        
    }

    public interface IRatingService : IBaseCrudService<Rating>
    {
        Rating addRatingPerson(Person person);
    }        

    public interface IAccountService : IBaseCrudService<Person>
    {
        PersonResponseDTO RegisterPerson(PersonDTO createPerson);
    }
}
