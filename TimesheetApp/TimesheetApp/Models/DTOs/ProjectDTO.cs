using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApp.Models
{
    public class ProjectDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }

        public double LoggedTime { get; set; }
    }
}
