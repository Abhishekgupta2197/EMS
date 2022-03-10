using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
    }
}
