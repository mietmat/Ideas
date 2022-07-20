using MotoAppv2.Components.CsvReader.Models;
using System.Collections.Generic;

namespace TaskManager.Components.CsvReader
{
    public interface ICsvReader
    {
        List<BuildingMaterial> ProcessBuildingMaterial(string filePath);

    }
}
