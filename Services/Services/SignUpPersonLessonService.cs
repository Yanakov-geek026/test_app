using Domain.School;
using DTO.Request;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services.Services
{
    public class SignUpPersonLessonService : BaseCrudService<SignUpPersonLesson>, ISignUpPersonLessonService
    {
        private ILessonService LessonService;
        private IPersonService PersonService;
        private ISubjectService SubjectService;

        public SignUpPersonLessonService(IRepository<SignUpPersonLesson> repository, 
            IPersonService personService, ILessonService lessonService, ISubjectService subjectService) : base(repository) 
        {
            LessonService = lessonService;
            PersonService = personService;
            SubjectService = subjectService;
        }

        public SignUpPersonLesson AddStudentOnLesson(AddPersonOnLessonDTO addPersonOnLesson)
        {
            var sub = SubjectService.Get(SubjectService.GetAll().FirstOrDefault(x => x.Name == addPersonOnLesson.Subject).Id);

            var record = new SignUpPersonLesson()
            {
                Person = PersonService.Get(PersonService.GetAll()
                    .FirstOrDefault(x => x.FirstName == addPersonOnLesson.FirstName && x.LastName == addPersonOnLesson.LastName).Id),
                Lesson = LessonService.Get(LessonService.GetAll()
                    .FirstOrDefault(x => x.Cabinet == addPersonOnLesson.Cabinet &&
                        x.Subject == sub).Id)
            };

            Create(record);
            return record;
        }
    }
}
