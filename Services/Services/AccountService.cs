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
        private IPersonService PersonService;
        private ISubjectService SubjectService;
        private IRatingService RatingService;
        
        public AccountService(IRepository<Person> repository, 
            IPersonService personService, ISubjectService subjectService, IRatingService ratingService ) : base(repository)
        {
            this.PersonService = personService;
            this.SubjectService = subjectService;
            this.RatingService = ratingService;
        }

        public PersonDTO RegisterPerson(CreatePersonDTO createPerson)
        {
            var person = PersonService.CreatePerson(createPerson);
            return new PersonDTO(person);
        }        

        public SubjectDTO AddNewSubject(CreateSubjectDTO createSubject)
        {
            var subject = SubjectService.addSubject(createSubject);
            return new SubjectDTO(subject);
        }

        public RatingDTO AddRatingPerson(CreateRatingDTO createRating)
        {
            var rating = RatingService.addRatingPerson(createRating);
            return new RatingDTO(rating);
        }
    }
}
