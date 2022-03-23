using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AssignTasks = new HashSet<AssignTask>();
            HoursWorkeds = new HashSet<HoursWorked>();
            Leaves = new HashSet<Leave>();
            PayTypes = new HashSet<PayType>();
            Pays = new HashSet<Pay>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;
        public string? Profile { get; set; }
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Department Department { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
        public virtual State State { get; set; } = null!;
        public virtual ICollection<AssignTask> AssignTasks { get; set; }
        public virtual ICollection<HoursWorked> HoursWorkeds { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<PayType> PayTypes { get; set; }
        public virtual ICollection<Pay> Pays { get; set; }
    }
}
