using Domain.Persons;
using DTO.Request;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class RatingService : BaseCrudService<Rating>, IRatingService
    {
        private IPersonService PersonService;
        private ISubjectService SubjectService;

        public RatingService(IRepository<Rating> repository, 
            IPersonService personService, ISubjectService subjectService) : base(repository) 
        {
            this.PersonService = personService;
            this.SubjectService = subjectService;
        }

        public Rating addRatingPerson(CreateRatingDTO createRating)
        {
            var idPerson = PersonService.GetAll()
                .FirstOrDefault(x => x.FirstName == createRating.FirstName && x.LastName == createRating.LastName).Id;
            var idSubject = SubjectService.GetAll()
                .FirstOrDefault(r => r.Name == createRating.Subject).Id;
            
            var rating = new Rating()
            {
                Person = PersonService.Get(idPerson),
                Subject = SubjectService.Get(idSubject),
                Value = createRating.Value
            };

            Create(rating);
            return rating;
        }
    }
}
