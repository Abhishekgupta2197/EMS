﻿using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Employee
    {
        public Employee()
        {
            HoursWorkeds = new HashSet<HoursWorked>();
            Leaves = new HashSet<Leave>();
            PayTypes = new HashSet<PayType>();
            Pays = new HashSet<Pay>();
            Tasks = new HashSet<Task>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;
        public string? Profile { get; set; }
        public string EmailId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DepartmentId { get; set; } = null!;
        public int PositionId { get; set; }
        public int AddressId { get; set; }

        public virtual ICollection<HoursWorked> HoursWorkeds { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<PayType> PayTypes { get; set; }
        public virtual ICollection<Pay> Pays { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
