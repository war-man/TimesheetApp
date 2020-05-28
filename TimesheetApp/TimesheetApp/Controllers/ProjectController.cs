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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Projects")]
        public ActionResult<List<ProjectDTO>> Projects()
        {
            return new OkObjectResult(_repository.Projects());
        }

        [HttpPost]
        [Route("AddProject")]
        public ActionResult AddProject([FromBody] ProjectNameDTO projectDTO)
        {
            return new OkObjectResult(_repository.AddProject(projectDTO));
        }
        [HttpPost]
        [Route("DisableProject")]
        public ActionResult DisableProject([FromBody] ProjectNameDTO projectDTO)
        {
            return new OkObjectResult(_repository.DisableProject(projectDTO));
        }
        [HttpPost]
        [Route("EnableProject")]
        public ActionResult EnableProject([FromBody] ProjectNameDTO projectDTO)
        {
            return new OkObjectResult(_repository.EnableProject(projectDTO));
        }
    }
}