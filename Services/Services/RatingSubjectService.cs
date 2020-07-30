using Domain.Persons;
using DTO.Response;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    class RatingSubjectService : BaseCrudService<Rating>, IRatingSubjectService
    {
        private IPersonService PersonService;
        private ISubjectService SubjectService;
        private IRatingService RatingService;

        public RatingSubjectService(IRepository<Rating> repository, 
            IPersonService personService, ISubjectService subjectService, IRatingService ratingService) : base(repository)
        {
            this.PersonService = personService;
            this.SubjectService = subjectService;
            this.RatingService = ratingService;
        }

        public IList<int> ShowRatingPerson(DataPersonRatinDTO dataPersonRatin)
        {
            var idPerson = PersonService.GetAll()
                .FirstOrDefault(x => x.FirstName == dataPersonRatin.FirstName && x.LastName == dataPersonRatin.LastName).Id;
            var idSubject = SubjectService.GetAll()
                .FirstOrDefault(s => s.Name == dataPersonRatin.SubjectName).Id;
            
            return RatingService.GetAll().Where(w => w.Person.Id == idPerson && w.Subject.Id == idSubject).Select(x => x.Value).ToList();
        }
    }
}
