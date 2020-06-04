using BusDepot.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BusDepot.DAL
{
    public class BusDepotContext : DbContext
    {
        public BusDepotContext() : base("BusDepotContext")
        {

            // disable initializer
            // Database.SetInitializer<BusDepotContext>(null);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RefuelReport> RefuelReports { get; set; }
        public DbSet<RepairReport> RepairReports { get; set; }
        public DbSet<WithdrawItemReport> WithdrawItemReports { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}