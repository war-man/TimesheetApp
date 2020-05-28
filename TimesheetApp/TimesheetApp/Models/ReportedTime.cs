using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApp.Models
{
    public class ReportedTime
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public long UserId { get; set; }
        public long ProjectId { get; set; }
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
