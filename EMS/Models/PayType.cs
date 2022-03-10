using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class PayType
    {
        public int PayTypeId { get; set; }
        public string PayType1 { get; set; } = null!;
        public int? EmployeeId { get; set; }
        public int? PayId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Pay? Pay { get; set; }
    }
}
