using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;

namespace TimesheetApp.Repositories
{
    public interface IProjectRepository
    {
        List<ProjectDTO> Projects();
        ActionResult AddProject(ProjectNameDTO projectDTO);
        ActionResult DisableProject(ProjectNameDTO projectDTO);
        ActionResult EnableProject(ProjectNameDTO projectDTO);
    }
}
