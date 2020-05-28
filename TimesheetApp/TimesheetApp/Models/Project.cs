using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApp.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }
        public ICollection<ReportedTime> ReportedTime { get; set; }
    }
}
