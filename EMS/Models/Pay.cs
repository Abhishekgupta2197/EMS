using System;
using System.Collections.Generic;

namespace EMS.Models
{
    public partial class Pay
    {
        public Pay()
        {
            PayTypes = new HashSet<PayType>();
        }

        public int PayId { get; set; }
        public int EmployeeId { get; set; }
        public double TotalHours { get; set; }
        public double TotalPay { get; set; }
        public double Taxes { get; set; }
        public double NetPay { get; set; }
        public int PunchId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual HoursWorked Punch { get; set; } = null!;
        public virtual ICollection<PayType> PayTypes { get; set; }
    }
}
