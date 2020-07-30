using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateTimeTableDTO
    {
        public string NameWeek { get; set; }
        public int Cabiten { get; set; }
        public string Subject { get; set; }
        public int Pair { get; set; }
    }
}
