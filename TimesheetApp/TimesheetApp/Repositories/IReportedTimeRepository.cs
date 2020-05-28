using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;

namespace TimesheetApp.Repositories
{
    public interface IReportedTimeRepository
    {
        List<ReportedTimeDTO> ReportedTime();
        List<ReportedTimeDTO> UserReportedTime(long userId);
        List<ReportedTimeDTO> ProjectReportedTime(long projectId);
        ActionResult<ReportedTime> AddReportedTime(ReportedTimeDTO reportedTime);
        ActionResult DeleteReportedTime(long reportTimeId);
        ActionResult UpdateReportTime(ReportedTimeDTO reportedTimeDTO);
    }
}
