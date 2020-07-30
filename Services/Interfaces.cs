using Domain.Persons;
using Domain.School;
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
        Person CreatePerson(CreatePersonDTO createPerson);
    }

    public interface IRatingService : IBaseCrudService<Rating>
    {
        Rating addRatingPerson(CreateRatingDTO createRating);
    }        

    public interface ISubjectService: IBaseCrudService<Subject>
    {
        Subject addSubject(CreateSubjectDTO createSubject);
    }

    public interface IRatingSubjectService: IBaseCrudService<Rating>
    {
        IList<int> ShowRatingPerson(DataPersonRatinDTO dataPersonRatin);
    }

    public interface ILessonService: IBaseCrudService<Lesson>
    {
        Lesson CreatyLesson(CreateLessonDTO createLesson);
    }

    public interface ISignUpPersonLessonService: IBaseCrudService<SignUpPersonLesson> {
        SignUpPersonLesson AddStudentOnLesson(AddPersonOnLessonDTO addPersonOnLesson);
    }

    public interface INumberLessonService: IBaseCrudService<NumberLesson> 
    {
        NumberLesson CreateNumberLesson(CreatyNumberLessonDTO creatyNumberLesson);
    }

    public interface ITimeTableService: IBaseCrudService<TimeTable>
    {
        TimeTable CreateTimeTable(CreateTimeTableDTO createTimeTable);
        string FindPerson(FindPersonDTO findPerson);
    }

    public interface IAccountService : IBaseCrudService<Person>
    {
        PersonDTO RegisterPerson(CreatePersonDTO createPerson);
        SubjectDTO AddNewSubject(CreateSubjectDTO createSubject);
        RatingDTO AddRatingPerson(CreateRatingDTO createRating);
    }
}
