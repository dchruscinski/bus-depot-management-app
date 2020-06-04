using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
        public int NumberOfItems { get; set; }
        public string ItemNotes { get; set; }

        public virtual ICollection<WithdrawItemReport> WithdrawItemReports { get; set; }
    }
}