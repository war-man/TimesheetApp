using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;
using TimesheetApp.Repositories;

namespace TimesheetApp.Services
{
    public class ProjectService : IProjectRepository
    {
        private readonly TimesheetContext _context;
        public ProjectService(TimesheetContext context)
        {
            _context = context;
        }

        public List<ProjectDTO> Projects()
        {
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
            var projects = _context.Project.Include(p => p.ReportedTime).ToList();
            foreach (var element in projects)
            {
                double fulltime = 0;
                foreach (var time in element.ReportedTime)
                {
                    fulltime += time.Amount;
                }
                projectDTOs.Add(new ProjectDTO()
                {
                    Id = element.Id,
                    Name = element.Name,
                    IsValid = element.IsValid,
                    LoggedTime = fulltime
                });
            }
            return projectDTOs;
        }
        public ActionResult AddProject(ProjectNameDTO projectDTO)
        {
            var newProject = new Project() { Name = projectDTO.Name, IsValid = true };
            _context.Add(newProject);
            _context.SaveChanges();
            return new OkObjectResult(newProject);
        }

        public ActionResult DisableProject(ProjectNameDTO projectDTO)
        {
            _context.Project.Update(new Project() { Id = projectDTO.Id, Name = projectDTO.Name, IsValid = false });
            _context.SaveChanges();
            return new OkResult();
        }
        public ActionResult EnableProject(ProjectNameDTO projectDTO)
        {
            _context.Project.Update(new Project() { Id = projectDTO.Id, Name = projectDTO.Name, IsValid = true });
            _context.SaveChanges();
            return new OkResult();
        }
    }
}
