using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;
using TimesheetApp.Repositories;

namespace TimesheetApp
{
    public class ReportedTimeService : IReportedTimeRepository
    {
        private readonly TimesheetContext _context;
        public ReportedTimeService(TimesheetContext context)
        {
            _context = context;
        }

        public List<ReportedTimeDTO> ReportedTime()
        {
            var reportedTimeDTOs = new List<ReportedTimeDTO>();
            var reportedTime = _context.ReportedTime
                    .Include(r => r.Project)
                    .Include(r => r.User)
                    .ToList();
            foreach (var element in reportedTime)
            {
                reportedTimeDTOs.Add(new ReportedTimeDTO()
                {
                    Id = element.Id,
                    Amount = element.Amount,
                    Date = element.Date,
                    User = element.User,
                    Project = new ProjectNameDTO() { Id = element.Project.Id, Name = element.Project.Name }
                });
            }
            return reportedTimeDTOs;
        }

        public List<ReportedTimeDTO> UserReportedTime(long userId)
        {
            var reportedTimeDTOs = new List<ReportedTimeDTO>();
            var reportedTime = _context.ReportedTime
                               .Where(r => r.UserId == userId)
                               .Include(r => r.Project)
                               .Include(r => r.User)
                               .ToList();
            foreach (var element in reportedTime)
            {
                reportedTimeDTOs.Add(new ReportedTimeDTO()
                {
                    Id = element.Id,
                    Amount = element.Amount,
                    Project = new ProjectNameDTO() { Id = element.Project.Id, Name = element.Project.Name },
                    Date = element.Date
                });
            }
            return reportedTimeDTOs;
        }

        public ActionResult<ReportedTime> AddReportedTime(ReportedTimeDTO reportedTime)
        {
            var newReport = new ReportedTime()
            {
                Amount = reportedTime.Amount,
                ProjectId = reportedTime.Project.Id,
                Date = reportedTime.Date,
                UserId = reportedTime.User.Id
            };
            _context.ReportedTime.Add(newReport);
            _context.SaveChanges();
            return new OkObjectResult(newReport);
        }

        public List<ReportedTimeDTO> ProjectReportedTime(long projectId)
        {
            var reportedTimeDTOs = new List<ReportedTimeDTO>();
            var reportedTime = _context.ReportedTime
                    .Include(r => r.Project)
                    .Include(r => r.User)
                    .ToList();

            return reportedTimeDTOs;
        }

        public ActionResult DeleteReportedTime(long reportTimeId)
        {
            var reportToDelete = _context.ReportedTime.FirstOrDefault(r => r.Id == reportTimeId);
            _context.ReportedTime.Remove(reportToDelete);
            _context.SaveChanges();
            return new OkResult();
        }

        public ActionResult UpdateReportTime(ReportedTimeDTO reportedTimeDTO)
        {
            var reportToUpdate = new ReportedTime()
            {
                Id = reportedTimeDTO.Id,
                Amount = reportedTimeDTO.Amount,
                Date = reportedTimeDTO.Date,
                ProjectId = reportedTimeDTO.Project.Id,
                UserId = reportedTimeDTO.User.Id
            };
            _context.ReportedTime.Update(reportToUpdate);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}
