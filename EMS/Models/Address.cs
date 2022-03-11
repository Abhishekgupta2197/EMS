using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Address
    {
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int CityId { get; set; }
        public int StateId { get; set; }
        public short CountryId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual Region State { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
