using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;
using TimesheetApp.Repositories;

namespace TimesheetApp.Services
{
    public class UserService : IUserRepository
    {
        private readonly TimesheetContext _context;
        public UserService(TimesheetContext context)
        {
            _context = context;
        }
        public ActionResult<UserDTO> LogIn(User user)
        {
            var userInDB = _context.User.FirstOrDefault(u => u.Email == user.Email);
            if (user.Password == userInDB.Password)
            {
                return new UserDTO()
                {
                    Id = userInDB.Id,
                    Email = user.Email,
                    FirstName = userInDB.FirstName,
                    LastName = userInDB.LastName,
                    IsAdmin = userInDB.IsAdmin
                };
            }
            return new UnauthorizedResult();
        }

        public ActionResult<UserDTO> SignIn(User user)
        {
            var isUser = _context.User.FirstOrDefault(u => u.Email == user.Email);
            if (isUser == null)
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return new UserDTO()
                {
                    Id = user.Id,
                    Email = user.Email
                };
            }
            return new BadRequestObjectResult(null);
        }
    }
}
