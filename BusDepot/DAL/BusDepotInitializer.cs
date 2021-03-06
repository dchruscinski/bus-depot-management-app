﻿using BusDepot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusDepot.DAL
{
    public class BusDepotInitializer : System.Data.Entity.
                    DropCreateDatabaseIfModelChanges<BusDepotContext>

    /*
     * CreateDatabaseIfNotExists
     * DropCreateDatabaseIfModelChanges
     * DropCreateDatabaseAlways
     * 
     */
    {
        protected override void Seed(BusDepotContext context)
        {
            var employee = new List<Employee>
            {
                new Employee{FirstName="Jan",LastName="Kowalski",Position="Mistrz warsztatu - brygada I",
                    PermissionLevel=5, Email="j.kowalski@mpk.torun.pl" , PhoneNumber="552132821"},

                new Employee{FirstName="Adam",LastName="Nowak",Position="Pracownik warsztatu - brygada I",
                    PermissionLevel=4, Email="a.nowak@mpk.torun.pl", PhoneNumber="552132831"},

                new Employee{FirstName="Mariusz",LastName="Knyp",Position="Pracownik stacji paliw",
                    PermissionLevel=3, Email="m.knyp@mpk.torun.pl", PhoneNumber="552132841"},

                new Employee{FirstName="Marian",LastName="Polej",Position="Magazynier",
                    PermissionLevel=2, Email="m.polej@mpk.torun.pl", PhoneNumber="552132851"},

                new Employee{FirstName="Romuald",LastName="Dzwon",Position="Pracownik MPK",
                    PermissionLevel=1, Email="r.dzwon@mpk.torun.pl", PhoneNumber="552132861"}
            };

            employee.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var fuel = new List<Fuel>
            {
                new Fuel{Name="IZ-40",TankID=1,AmountOfFuel=35000},

                new Fuel{Name="Eurodiesel",TankID=2,AmountOfFuel=25000},

                new Fuel{Name="Pb98",TankID=3,AmountOfFuel=10000},

                new Fuel{Name="Pb95",TankID=3,AmountOfFuel=10000}
            };

            fuel.ForEach(f => context.Fuels.Add(f));
            context.SaveChanges();

            var item = new List<Item>
            {
                new Item{Name="Szyba - przód - Solaris Urbino III",Sector="A",NumberOfItems=1,
                    ItemNotes="Połówka przedniej szyby do Solarisa III generacji"},

                new Item{Name="Kasownik - z godziną",Sector="B",NumberOfItems=12,
                    ItemNotes="Kasownik z wyświetlaczem godziny"},

                new Item{Name="Żarówka - światło mijania - Jelcz",Sector="C",NumberOfItems=5,
                    ItemNotes="Żarówka światła mijania do Jelcza"},

                new Item{Name="Maskownica zderzaka - przód - MAN Lion's City",Sector="D",NumberOfItems=2,
                    ItemNotes="Maskownica zderzaka przedniego do MANa Lion's City"},

                new Item{Name="Kierownica - Solaris",Sector="B",NumberOfItems=3,
                    ItemNotes="Obszyta oryginalna kierowca do Solarisa"}
            };

            item.ForEach(i => context.Items.Add(i));
            context.SaveChanges();

            var bus = new List<Bus>
            {
                new Bus{SideNumber=516,IsFunctional=true,CarRegistration="CT43035",CarModelAndMake="Jelcz 120MM/2",
                    EngineType="DO 826 LUH 12",VIN="SUJ120MAE30000420",EngineCapacity=6871,EnginePower=162,
                    EmissionStandard="Euro II", TransmissionMakeAndType="VOITH D851.3E",NumberOfStandingPlaces=76,NumberOfSeats=34,
                    RegistrationDate=DateTime.Parse("2003-12-01")},

                new Bus{SideNumber=545,IsFunctional=true,CarRegistration="CT98064",CarModelAndMake="MAN NL273 Lion's City",
                    EngineType="D 2066 LUH 21",VIN="WMAA21ZZ87R004456",EngineCapacity=10518,EnginePower=199,
                    EmissionStandard="Euro IV",TransmissionMakeAndType="VOITH D864.5",NumberOfStandingPlaces=78,NumberOfSeats=29,
                    RegistrationDate=DateTime.Parse("2007-10-05")},

                new Bus{SideNumber=571,IsFunctional=false,CarRegistration="CT9913G",CarModelAndMake="Solaris Urbino 12 III",
                    EngineType="DAF PR228 U1",VIN="SUU241161BB010444",EngineCapacity=9186,EnginePower=231,
                    EmissionStandard="Euro V",TransmissionMakeAndType="VOITH D864.5",NumberOfStandingPlaces=72,NumberOfSeats=29,
                    RegistrationDate=DateTime.Parse("2011-11-30")},

                new Bus{SideNumber=617,IsFunctional=true,CarRegistration="CT7436S",CarModelAndMake="Solaris Urbino 12 IV",
                    EngineType="DAF PACCAR MX-11210 H1",VIN="SUU241161JB019750",EngineCapacity=10837,EnginePower=210,
                    EmissionStandard="Euro VI",TransmissionMakeAndType="VOITH DIVA 6",NumberOfStandingPlaces=57,NumberOfSeats=28,
                    RegistrationDate=DateTime.Parse("2018-11-18")},

                new Bus{SideNumber=642,IsFunctional=true,CarRegistration="CT8501S",CarModelAndMake="MAN Lion's City NL253/3T/Hybrid",
                    EngineType="D0836LOH82",VIN="WMAA37ZZ6KF008934",EngineCapacity=6871,EnginePower=184,
                    EmissionStandard="Euro VI",TransmissionMakeAndType="VOITH DIVA 6",NumberOfStandingPlaces=50,NumberOfSeats=29,
                    RegistrationDate=DateTime.Parse("2018-12-14")},
            };

            bus.ForEach(b => context.Buses.Add(b));
            context.SaveChanges();

            var car = new List<Car>
            {
                new Car{SideNumber=31,IsFunctional=true,CarRegistration="CT7432G",CarModelAndMake="Skoda Octavia 3 Kombi",
                    EngineType="1.4 TSI",VIN="3VWLL7AJ0EM408116",EngineCapacity=1395,EnginePower=103,
                    RegistrationDate=DateTime.Parse("2014-01-23"), Depot="Zajezdnia autobusowa, Legionów"},

                new Car{SideNumber=21,IsFunctional=true,CarRegistration="CT54413",CarModelAndMake="Fiat Panda I Hatchback",
                    EngineType="1.1 SELECTA CLX",VIN="3GYFK62817G278819",EngineCapacity=1108,EnginePower=40,
                    RegistrationDate=DateTime.Parse("2003-08-04"), Depot="Zajezdnia autobusowa, Legionów"},
            };

            car.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();

            var refuelReport = new List<RefuelReport>
            {
                new RefuelReport{FuelID=2,AmountOfTakenFuel=128.93M,EmployeeID=3,VehicleID=1,
                    RefuelDateTime=DateTime.Parse("2019-11-28 23:12:04")},

                new RefuelReport{FuelID=1,AmountOfTakenFuel=152.41M,EmployeeID=3,VehicleID=2,
                    RefuelDateTime=DateTime.Parse("2019-11-28 23:34:55")},

                new RefuelReport{FuelID=3,AmountOfTakenFuel=42.22M,EmployeeID=3,VehicleID=6,
                    RefuelDateTime=DateTime.Parse("2019-11-29 10:33:37")},

                new RefuelReport{FuelID=4,AmountOfTakenFuel=39.58M,EmployeeID=3,VehicleID=7,
                    RefuelDateTime=DateTime.Parse("2019-11-29 12:16:41")}
            };

            refuelReport.ForEach(r => context.RefuelReports.Add(r));
            context.SaveChanges();

            var withdrawItemReport = new List<WithdrawItemReport>
            {
                new WithdrawItemReport{ItemID=1,NumberOfTakenItems=1,EmployeeID=2,VehicleID=3,
                    WithdrawItemDateTime=DateTime.Parse("2019-11-17 17:33:44")},
                new WithdrawItemReport{ItemID=2,NumberOfTakenItems=1,EmployeeID=2,VehicleID=3,
                    WithdrawItemDateTime=DateTime.Parse("2019-11-17 21:11:29")},
                new WithdrawItemReport{ItemID=3,NumberOfTakenItems=2,EmployeeID=1,VehicleID=1,
                    WithdrawItemDateTime=DateTime.Parse("2019-11-18 04:02:56")},
                new WithdrawItemReport{ItemID=4,NumberOfTakenItems=1,EmployeeID=2,VehicleID=2,
                    WithdrawItemDateTime=DateTime.Parse("2019-11-21 12:25:37")},
                new WithdrawItemReport{ItemID=5,NumberOfTakenItems=1,EmployeeID=1,VehicleID=4,
                    WithdrawItemDateTime=DateTime.Parse("2019-11-25 19:04:08")},
            };

            withdrawItemReport.ForEach(w => context.WithdrawItemReports.Add(w));
            context.SaveChanges();

            var repairReport = new List<RepairReport>
            {
                new RepairReport{EmployeeID=1,VehicleID=3,
                    RepairDateTime=DateTime.Parse("2019-11-17 21:52:51")},

                new RepairReport{EmployeeID=1,VehicleID=1,
                    RepairDateTime=DateTime.Parse("2019-11-18 04:08:16")},

                new RepairReport{EmployeeID=1,VehicleID=2,
                    RepairDateTime=DateTime.Parse("2019-11-21 13:44:35")},

                new RepairReport{EmployeeID=1,VehicleID=4,
                    RepairDateTime=DateTime.Parse("2019-11-25 21:38:24")},
            };

            repairReport.ForEach(r => context.RepairReports.Add(r));
            context.SaveChanges();
        }
    }
}