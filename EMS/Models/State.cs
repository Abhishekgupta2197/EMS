using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Employees = new HashSet<Employee>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; } = null!;
        public int StateCountryId { get; set; }

        public virtual Country StateCountry { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
