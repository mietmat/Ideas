
using MotoAppv2.Components.CsvReader.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {


        public List<BuildingMaterial> ProcessBuildingMaterial(string filePath)
        {

            if (!File.Exists(filePath))
            {
                return new List<BuildingMaterial>();
            }

            var buidlingMaterials =
                File.ReadAllLines(filePath)
                .Where(x => x.Length > 5)
                .Select(x =>
                {
                    var columns = x.Split(';');
                    return new BuildingMaterial()
                    {
                        Symbol = columns[0],
                        Name = columns[1],
                        ThermalConductivitySW = decimal.Parse(columns[2]),
                        ThermalConductivityW = decimal.Parse(columns[3]),
                        Density = decimal.Parse(columns[4]),
                        SpecificHeat = decimal.Parse(columns[5])

                    };
                });

            return buidlingMaterials.ToList();
        }
    }
}
