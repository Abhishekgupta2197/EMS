using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Leave
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public string ReasonForLeave { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;
    }
}
