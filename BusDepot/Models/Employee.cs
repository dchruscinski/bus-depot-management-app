using System;
using System.Collections.Generic;
namespace BusDepot.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullIdentificator
        {
            get { return FirstName + " " + LastName + ", " + Position; }
        }
        public string Position { get; set; }
        public int PermissionLevel { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<WithdrawItemReport> WithdrawItemReports { get; set; }
        public virtual ICollection<RepairReport> RepairReports { get; set; }
        public virtual ICollection<RefuelReport> RefuelReports { get; set; }
    }
}
