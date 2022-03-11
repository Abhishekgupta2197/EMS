using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string? PositionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
