using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateLessonDTO
    {
        public string Subject { get; set; }
        public int Number { get; set; }                
    }
}
