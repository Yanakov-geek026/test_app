using Domain.School;
using DTO.Request;
using Storage.Interfaces;

namespace Services.Services
{
    public class NumberLessonService : BaseCrudService<NumberLesson>, INumberLessonService
    {
        public NumberLessonService(IRepository<NumberLesson> repository) : base(repository) { }

        public NumberLesson CreateNumberLesson(CreatyNumberLessonDTO creatyNumberLesson)
        {
            var numberLesson = new NumberLesson()
            {
                Number = creatyNumberLesson.Number,
                TimeStart = creatyNumberLesson.TimeStart,
                TimeEnd = creatyNumberLesson.TimeEnd
            };

            Create(numberLesson);
            return numberLesson;
        }
    }
}
