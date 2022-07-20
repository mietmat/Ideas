using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace MotoAppv2.Components.CsvReader.Models
{
    public class BuildingMaterial : EntityBase
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal ThermalConductivitySW { get; set; }
        public decimal ThermalConductivityW { get; set; }
        public decimal Density { get; set; }
        public decimal SpecificHeat { get; set; }


    }
}
