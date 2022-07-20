using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface IBuildingMaterialRepository
    {
        BuildingMaterialModel Get(int taskId);
        IQueryable<BuildingMaterialModel> GetAllActive();
        void Add(BuildingMaterialModel task);
        void Update(int taskId, BuildingMaterialModel task);
        void Delete(int taskId);
        void DeleteAll();

    }
}
