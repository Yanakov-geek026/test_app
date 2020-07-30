using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreatePersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexType SexType { get; set; }
    }
}
