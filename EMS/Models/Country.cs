using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public string Language { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<State> States { get; set; }
    }
}
