using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public class Fuel
    {
        public int FuelID { get; set; }
        public string Name { get; set; }
        public int TankID { get; set; }
        public double AmountOfFuel { get; set; }

        public virtual ICollection<RefuelReport> RefuelReports { get; set; }
    }
}