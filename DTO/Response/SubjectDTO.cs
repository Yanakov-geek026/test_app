using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class SubjectDTO
    {
        public long Id { get; set; }
        public string Name { get;set; }

        public SubjectDTO() { }

        public SubjectDTO(Subject subject)
            
        {
            if (subject == null)
                return;

            Id = subject.Id;
            Name = subject.Name;
        }
    }
}
