using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;
using TimesheetApp.Repositories;

namespace TimesheetApp.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("LogIn")]
        public ActionResult<UserDTO> LogIn([FromBody] User user)
        {
            return _repository.LogIn(user);
        }

        [HttpPost]
        [Route("SignUn")]
        public ActionResult<UserDTO> SignIn([FromBody] User user)
        {
            return _repository.SignIn(user);
        }
    }
}