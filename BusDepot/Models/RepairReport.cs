using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public class RepairReport
    {
        public int RepairReportID { get; set; }
        public int EmployeeID { get; set; }
        public int VehicleID { get; set; }
        public DateTime RepairDateTime { get; set; }
        public string RepairReportNotes { get; set; }

        public virtual ICollection<WithdrawItemReport> WithdrawItemReports { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual Car Car { get; set; }
    }
}