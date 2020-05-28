using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApp.Models.DTOs
{
    public class ReportedTimeDTO
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public virtual User User { get; set; }
        public virtual ProjectNameDTO Project { get; set; }
    }
}
