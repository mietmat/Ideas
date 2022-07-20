using System.Collections.Generic;
using System.Linq;
using TaskManager.Components.CsvReader;
using TaskManager.Models;


namespace TaskManager.Repositories
{
    public class BuildingMaterialRepository : IBuildingMaterialRepository
    {
        private readonly TaskManagerContext _context;
        private readonly ICsvReader _csvReader;


        public BuildingMaterialRepository(TaskManagerContext context, ICsvReader csvReader)
        {
            _context = context;
            _csvReader = csvReader;
            _context.Database.EnsureCreated();
                     
        }

        public BuildingMaterialModel Get(int buildingMaterialId)
        {
            return _context.BuildingMaterialModel.SingleOrDefault(x => x.Id == buildingMaterialId);
        }

        public IQueryable<BuildingMaterialModel> GetAllActive()
        {
            var count = _context.BuildingMaterialModel.Count();
            if (count == 0)
            {
                InsertData();
            }
            return _context.BuildingMaterialModel.Where(x => !x.Done);
        }
        public void Add(BuildingMaterialModel buildingMaterial)
        {
            _context.BuildingMaterialModel.Add(buildingMaterial);
            _context.SaveChanges();
        }

        public void Update(int id, BuildingMaterialModel buildingMaterial)
        {
            var result = _context.BuildingMaterialModel.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Symbol = buildingMaterial.Symbol;
                result.Name = buildingMaterial.Name;
                result.ThermalConductivitySW = buildingMaterial.ThermalConductivitySW;
                result.ThermalConductivityW = buildingMaterial.ThermalConductivityW;
                result.Density = buildingMaterial.Density;
                result.SpecificHeat = buildingMaterial.SpecificHeat;
                result.Done = buildingMaterial.Done;

            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _context.BuildingMaterialModel.SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                _context.BuildingMaterialModel.Remove(result);
                _context.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            List<BuildingMaterialModel> results = _context.BuildingMaterialModel.Where(x => x.Id > 0).ToList();
            foreach (var result in results)
            {
                _context.BuildingMaterialModel.Remove(result);

            }
            _context.SaveChanges();


        }


        public void InsertData()
        {
            var materials = _csvReader.ProcessBuildingMaterial("C:\\Users\\mateu\\Desktop\\Projekty c#\\TaskManager\\TaskManager\\Resources\\BuildingMaterials.csv");

            foreach (var material in materials)
            {
                _context.BuildingMaterialModel.Add(new BuildingMaterialModel()
                {
                    Name = material.Name,
                    Symbol = material.Symbol,
                    ThermalConductivitySW = material.ThermalConductivitySW,
                    ThermalConductivityW = material.ThermalConductivityW,
                    Density = material.Density,
                    SpecificHeat = material.SpecificHeat

                });

            }

            _context.SaveChanges();
        }

    }
}
