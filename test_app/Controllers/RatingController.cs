using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_app.Controllers
{
    public class RatingController : BaseController
    {
        private IRatingSubjectService RatingSubjectService;

        public RatingController(IRatingSubjectService ratingSubjectService)
        {
            RatingSubjectService = ratingSubjectService;
        }

        [HttpGet(nameof(getListRatingPerson))]
        public IActionResult getListRatingPerson(DataPersonRatinDTO dataPersonRatin)
            => Ok(RatingSubjectService.ShowRatingPerson(dataPersonRatin));
    }
}
