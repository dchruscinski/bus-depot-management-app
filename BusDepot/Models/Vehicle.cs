using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusDepot.Models
{
    public abstract class Vehicle
    {
        public int VehicleID { get; set; }
        public int SideNumber { get; set; }
        public bool IsFunctional { get; set; }
        public string CarRegistration { get; set; }
        public string CarModelAndMake { get; set; }
        public string FullIdentificator
        {
            get { return "#" + SideNumber + ": " + CarModelAndMake; }
        }
        public string EngineType { get; set; }
        public string VIN { get; set; }
        public int EngineCapacity { get; set; }
        public int EnginePower { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }
    }
}