using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public class Car : Vehicle
    {
        public string Depot { get; set; }
        
        public virtual ICollection<RepairReport> RepairReports { get; set; }
        public virtual ICollection<WithdrawItemReport> WithdrawItemReports { get; set; }
        public virtual ICollection<RefuelReport> RefuelReports { get; set; }
    }
}