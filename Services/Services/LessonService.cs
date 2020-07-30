using Domain.School;
using DTO.Request;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class LessonService : BaseCrudService<Lesson>, ILessonService
    {
        private ISubjectService SubjectService;

        public LessonService(IRepository<Lesson> repository, ISubjectService subjectService) : base(repository)
        {
            SubjectService = subjectService;
        }

        public Lesson CreatyLesson(CreateLessonDTO createLesson)
        {
            var lesson = new Lesson()
            {
                Cabinet = createLesson.Number,
                Subject = SubjectService.Get(SubjectService.GetAll().FirstOrDefault(x => x.Name == createLesson.Subject).Id),
            };

            Create(lesson);
            return lesson;
        }
    }
}
