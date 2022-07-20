using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    [Table("BuildingMaterial")]
    public class BuildingMaterialModel : EntityBase
    {
        [DisplayName("Symbol")]
        public string Symbol { get; set; }

        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [DisplayName("λsw [W/mK]")]
        public decimal ThermalConductivitySW { get; set; }

        [DisplayName("λw [W/mK]")]
        public decimal ThermalConductivityW { get; set; }

        [DisplayName("ρ[kg / m3]")]
        public decimal Density { get; set; }

        [DisplayName("Cw [kJ/kgK]")]
        public decimal SpecificHeat { get; set; }
        public bool Done { get; set; }

    }
}
