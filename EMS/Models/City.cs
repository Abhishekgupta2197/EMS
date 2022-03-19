using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class City
    {
        public City()
        {
            Employees = new HashSet<Employee>();
        }

        public int CityId { get; set; }
        public int CityStateId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual State CityState { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
