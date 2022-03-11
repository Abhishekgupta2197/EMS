using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class HoursWorked
    {
        public HoursWorked()
        {
            Pays = new HashSet<Pay>();
        }

        public int PunchId { get; set; }
        public DateTime PunchInTime { get; set; }
        public DateTime PunchOutTime { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<Pay> Pays { get; set; }
    }
}
