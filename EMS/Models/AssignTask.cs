using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class AssignTask
    {
        public int AssignTaskId { get; set; }
        public string AssignTaskName { get; set; } = null!;
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
