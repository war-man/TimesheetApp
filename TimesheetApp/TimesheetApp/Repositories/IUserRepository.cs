using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;

namespace TimesheetApp.Repositories
{
    public interface IUserRepository
    {
        ActionResult<UserDTO> SignIn(User user);
        ActionResult<UserDTO> LogIn(User user);
    }
}
