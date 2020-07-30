using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class SubjectService : BaseCrudService<Subject>, ISubjectService
    {
        public SubjectService(IRepository<Subject> repository) : base(repository) { }

        public Subject addSubject(CreateSubjectDTO createSubject)
        {
            var subject = new Subject()
            {
                Name = createSubject.Name
            };

            Create(subject);
            return subject;
        }
    }
}
