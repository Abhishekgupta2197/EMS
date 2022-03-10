using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
