using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public class Bus : Vehicle
    {
        public string EmissionStandard { get; set; }
        public string TransmissionMakeAndType { get; set; }
        public int? NumberOfStandingPlaces { get; set; }
        public int? NumberOfSeats { get; set; }

        public virtual ICollection<RepairReport> RepairReports { get; set; }
        public virtual ICollection<WithdrawItemReport> WithdrawItemReports { get; set; }
        public virtual ICollection<RefuelReport> RefuelReports { get; set; }
    }
}