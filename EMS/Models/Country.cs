using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            Regions = new HashSet<Region>();
        }

        public short Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Language { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
