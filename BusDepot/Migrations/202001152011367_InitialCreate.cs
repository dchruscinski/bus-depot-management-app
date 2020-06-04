namespace BusDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        SideNumber = c.Int(nullable: false),
                        IsFunctional = c.Boolean(nullable: false),
                        CarRegistration = c.String(),
                        CarModelAndMake = c.String(),
                        EngineType = c.String(),
                        VIN = c.String(),
                        EngineCapacity = c.Int(nullable: false),
                        EnginePower = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        EmissionStandard = c.String(),
                        TransmissionMakeAndType = c.String(),
                        NumberOfStandingPlaces = c.Int(),
                        NumberOfSeats = c.Int(),
                        Depot = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.VehicleID);
            
            CreateTable(
                "dbo.RefuelReport",
                c => new
                    {
                        RefuelReportID = c.Int(nullable: false, identity: true),
                        FuelID = c.Int(nullable: false),
                        AmountOfTakenFuel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        RefuelDateTime = c.DateTime(nullable: false),
                        RefuelReportNotes = c.String(),
                        Item_ItemID = c.Int(),
                    })
                .PrimaryKey(t => t.RefuelReportID)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Fuel", t => t.FuelID, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.Item_ItemID)
                .Index(t => t.FuelID)
                .Index(t => t.EmployeeID)
                .Index(t => t.VehicleID)
                .Index(t => t.Item_ItemID);
            
            CreateTable(
                "dbo.RepairReport",
                c => new
                    {
                        RepairReportID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        RepairDateTime = c.DateTime(nullable: false),
                        RepairReportNotes = c.String(),
                    })
                .PrimaryKey(t => t.RepairReportID)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        PermissionLevel = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.WithdrawItemReport",
                c => new
                    {
                        WithdrawItemReportID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        NumberOfTakenItems = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        WithdrawItemDateTime = c.DateTime(nullable: false),
                        WithdrawItemReportNotes = c.String(),
                        RepairReport_RepairReportID = c.Int(),
                    })
                .PrimaryKey(t => t.WithdrawItemReportID)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.RepairReport", t => t.RepairReport_RepairReportID)
                .Index(t => t.ItemID)
                .Index(t => t.EmployeeID)
                .Index(t => t.VehicleID)
                .Index(t => t.RepairReport_RepairReportID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sector = c.String(),
                        NumberOfItems = c.Int(nullable: false),
                        ItemNotes = c.String(),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.Fuel",
                c => new
                    {
                        FuelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TankID = c.Int(nullable: false),
                        AmountOfFuel = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FuelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RefuelReport", "Item_ItemID", "dbo.Item");
            DropForeignKey("dbo.RefuelReport", "FuelID", "dbo.Fuel");
            DropForeignKey("dbo.WithdrawItemReport", "RepairReport_RepairReportID", "dbo.RepairReport");
            DropForeignKey("dbo.WithdrawItemReport", "ItemID", "dbo.Item");
            DropForeignKey("dbo.WithdrawItemReport", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.WithdrawItemReport", "VehicleID", "dbo.Vehicle");
            DropForeignKey("dbo.RepairReport", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.RefuelReport", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.RepairReport", "VehicleID", "dbo.Vehicle");
            DropForeignKey("dbo.RefuelReport", "VehicleID", "dbo.Vehicle");
            DropIndex("dbo.WithdrawItemReport", new[] { "RepairReport_RepairReportID" });
            DropIndex("dbo.WithdrawItemReport", new[] { "VehicleID" });
            DropIndex("dbo.WithdrawItemReport", new[] { "EmployeeID" });
            DropIndex("dbo.WithdrawItemReport", new[] { "ItemID" });
            DropIndex("dbo.RepairReport", new[] { "VehicleID" });
            DropIndex("dbo.RepairReport", new[] { "EmployeeID" });
            DropIndex("dbo.RefuelReport", new[] { "Item_ItemID" });
            DropIndex("dbo.RefuelReport", new[] { "VehicleID" });
            DropIndex("dbo.RefuelReport", new[] { "EmployeeID" });
            DropIndex("dbo.RefuelReport", new[] { "FuelID" });
            DropTable("dbo.Fuel");
            DropTable("dbo.Item");
            DropTable("dbo.WithdrawItemReport");
            DropTable("dbo.Employee");
            DropTable("dbo.RepairReport");
            DropTable("dbo.RefuelReport");
            DropTable("dbo.Vehicle");
        }
    }
}
