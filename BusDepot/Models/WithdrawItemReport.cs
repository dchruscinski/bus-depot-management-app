using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public class WithdrawItemReport
    {
        public int WithdrawItemReportID { get; set; }
        public int ItemID { get; set; }
        public int NumberOfTakenItems { get; set; }
        public int EmployeeID { get; set; }
        public int VehicleID { get; set; }
        public DateTime WithdrawItemDateTime { get; set; }
        public string WithdrawItemReportNotes { get; set; }

        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual Car Car { get; set; }
        public virtual RepairReport RepairReport { get; set; }
    }
}