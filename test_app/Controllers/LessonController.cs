using DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_app.Controllers
{
    public class LessonController : BaseController
    {
        private readonly ILessonService LessonService;
        private readonly ISignUpPersonLessonService SignUpPersonLessonService;
        private readonly INumberLessonService NumberLessonService;
        private readonly ITimeTableService TimeTableService;
        private readonly IPersonService PersonServiceService;

        public LessonController(ILessonService lessonService, ISignUpPersonLessonService signUpPersonLessonService, 
            INumberLessonService numberLessonService, ITimeTableService timeTableService, IPersonService personServiceService)
        {
            SignUpPersonLessonService = signUpPersonLessonService;
            LessonService = lessonService;
            NumberLessonService = numberLessonService;
            TimeTableService = timeTableService;
            PersonServiceService = personServiceService;
        }

        [HttpPost(nameof(createLesson))]
        public IActionResult createLesson([FromBody] CreateLessonDTO request)
            => Ok(LessonService.CreatyLesson(request));

        [HttpPost(nameof(recordPersonLesson))]
        public IActionResult recordPersonLesson([FromBody] AddPersonOnLessonDTO request)
            => Ok(SignUpPersonLessonService.AddStudentOnLesson(request));

        [HttpPost(nameof(createNumberLesson))]
        public IActionResult createNumberLesson([FromBody] CreatyNumberLessonDTO request)
            => Ok(NumberLessonService.CreateNumberLesson(request));

        [HttpPost(nameof(createTimeTable))]
        public IActionResult createTimeTable([FromBody] CreateTimeTableDTO request)
            => Ok(TimeTableService.CreateTimeTable(request));

        [HttpGet(nameof(findStudent))]
        public IActionResult findStudent(FindPersonDTO request)
            => Ok(TimeTableService.FindPerson(request));
    }
}
