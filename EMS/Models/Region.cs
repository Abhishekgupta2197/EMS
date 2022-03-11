using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Region
    {
        public Region()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public short CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
