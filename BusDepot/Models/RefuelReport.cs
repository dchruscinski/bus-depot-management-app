using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public class RefuelReport
    {
        public int RefuelReportID { get; set; }
        public int FuelID { get; set; }
        public decimal AmountOfTakenFuel { get; set; }
        public int EmployeeID { get; set; }
        public int VehicleID { get; set; }
        public DateTime RefuelDateTime { get; set; }
        public string RefuelReportNotes { get; set; }

        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual Car Car { get; set; }
        public virtual Fuel Fuel { get; set; }
    }
}