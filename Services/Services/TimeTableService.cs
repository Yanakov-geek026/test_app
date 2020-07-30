using Domain.School;
using DTO.Request;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class TimeTableService : BaseCrudService<TimeTable>, ITimeTableService
    {
        private ILessonService LessonService;
        private INumberLessonService NumberLessonService;
        private ISubjectService SubjectService;
        private ISignUpPersonLessonService SignUpPersonLessonService;
        private IPersonService PersonService;

        public TimeTableService(IRepository<TimeTable> repository, 
            ILessonService lessonService, INumberLessonService numberLessonService, 
            ISubjectService subjectService, ISignUpPersonLessonService signUpPersonLessonService, 
            IPersonService personService) : base(repository) 
        {
            LessonService = lessonService;
            NumberLessonService = numberLessonService;
            SubjectService = subjectService;
            SignUpPersonLessonService = signUpPersonLessonService;
            PersonService = personService;
        }

        public TimeTable CreateTimeTable(CreateTimeTableDTO createTimeTable)
        {
            var subject = SubjectService.Get(SubjectService.GetAll().FirstOrDefault(x => x.Name == createTimeTable.Subject).Id);

            var timeTable = new TimeTable()
            {
                NameWeek = createTimeTable.NameWeek,
                Lesson = LessonService.Get(LessonService.GetAll().FirstOrDefault(x => x.Cabinet == createTimeTable.Cabiten && x.Subject == subject).Id),
                NumberLesson = NumberLessonService.Get(NumberLessonService.GetAll().FirstOrDefault(x => x.Number == createTimeTable.Pair).Id)
            };

            Create(timeTable);
            return timeTable;
        }

        public string FindPerson(FindPersonDTO findPerson)
        {
            var person = PersonService.Get(PersonService.GetAll().FirstOrDefault(x => x.FirstName == findPerson.firstName && x.LastName == findPerson.lastName).Id);

            //try
            //{
            //    timeTable = Get(
            //        GetAll().FirstOrDefault(
            //            x => x.NameWeek == DateTime.Now.DayOfWeek.ToString() &&
            //            Convert.ToDateTime(x.NumberLesson.TimeStart) <= DateTime.Now &&
            //            Convert.ToDateTime(x.NumberLesson.TimeEnd) >= DateTime.Now &&
            //            x.Lesson == SignUpPersonLessonService.Get(SignUpPersonLessonService.GetAll().FirstOrDefault(y => y.Person == person).Id).Lesson).Id);
            //}
            //catch (Exception)
            //{
            //    return $"Student {findPerson.firstName} {findPerson.lastName} is at recess or at home";
            //}

            var timeLessonSchool = NumberLessonService.GetAll().ToList();
            NumberLesson numberLessonClass = new NumberLesson();

            for (int i = 0; i < timeLessonSchool.Count; i++)
            {
                if (Convert.ToDateTime(timeLessonSchool[i].TimeStart) <= Convert.ToDateTime("09:00:00") && Convert.ToDateTime(timeLessonSchool[i].TimeEnd) >= Convert.ToDateTime("09:00:00"))
                {
                    numberLessonClass = timeLessonSchool[i];
                    break;
                }
            }
            //DateTime.Now.DayOfWeek.ToString()
            var studentLesson = Get(GetAll().FirstOrDefault(x => x.NumberLesson == numberLessonClass && x.NameWeek == "Monday").Id);

            if (SignUpPersonLessonService.GetAll().Any(x => x.Lesson == studentLesson.Lesson && x.Person == person))
                return $"Student {findPerson.firstName} {findPerson.lastName} is located {studentLesson.Lesson.Cabinet} in class is {studentLesson.Lesson.Subject.Name}";
            else
                return $"Student {findPerson.firstName} {findPerson.lastName} at recess or at home";
            
        }
    }
}
