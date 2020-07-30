using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateRatingDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public int Value { get; set; }
    }
}
