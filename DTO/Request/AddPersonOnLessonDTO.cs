using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class AddPersonOnLessonDTO
    {
        public string Subject { get; set; }
        public int Cabinet { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
