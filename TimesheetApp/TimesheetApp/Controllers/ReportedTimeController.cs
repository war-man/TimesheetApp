using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimesheetApp.Models;
using TimesheetApp.Models.DTOs;
using TimesheetApp.Repositories;

namespace TimesheetApp.Controllers
{
    [ApiController]
    public class ReportedTimeController : ControllerBase
    {
        private readonly IReportedTimeRepository _repository;
        public ReportedTimeController(IReportedTimeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("ReportedTime")]
        public ActionResult<List<ReportedTimeDTO>> ReportedTime()
        {
            return new OkObjectResult(_repository.ReportedTime());
        }

        [HttpGet]
        [Route("ReportedTime/{userId}")]
        public ActionResult<List<ReportedTimeDTO>> GetReportedTime([FromRoute] long userId)
        {
            return new OkObjectResult(_repository.UserReportedTime(userId));
        }

        [HttpPost]
        [Route("AddTime")]
        public ActionResult Post([FromBody] ReportedTimeDTO reportedTime)
        {
            return new OkObjectResult(_repository.AddReportedTime(reportedTime));
        }

        [HttpDelete]
        [Route("DeleteTime/{id}")]
        public ActionResult Delete([FromRoute]long id)
        {
            return new OkObjectResult(_repository.DeleteReportedTime(id));
        }

        [HttpPut]
        [Route("UpdateTime/{id}")]
        public ActionResult Put(int id, [FromBody] ReportedTimeDTO reportedTimeDTO)
        {
            return new OkObjectResult(_repository.UpdateReportTime(reportedTimeDTO));
        }


    }
}
