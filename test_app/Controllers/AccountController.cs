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
    public class AccountController : BaseController
    {
        private readonly IAccountService AccountService;

        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }

        [HttpPost(nameof(createPerson))]
        public IActionResult createPerson([FromBody] CreatePersonDTO request)
            => Ok(AccountService.RegisterPerson(request));

        [HttpPost(nameof(addNewSubject))]
        public IActionResult addNewSubject([FromBody] CreateSubjectDTO request)
            => Ok(AccountService.AddNewSubject(request));

        [HttpPost(nameof(addRatingPerson))]
        public IActionResult addRatingPerson([FromBody] CreateRatingDTO request)
            => Ok(AccountService.AddRatingPerson(request));





    }
}
