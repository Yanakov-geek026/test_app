using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class RatingDTO
    {
        public long Id { get; set; }
        public int Value { get; set; }

        public RatingDTO() { }

        public RatingDTO(Rating rating)
        {
            if (rating == null)
                return;

            Id = rating.Id;
            Value = rating.Value;
        }
    }
}
