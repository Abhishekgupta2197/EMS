using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
