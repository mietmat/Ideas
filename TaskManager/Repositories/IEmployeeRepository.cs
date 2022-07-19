using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeModel Get(int taskId);
        IQueryable<EmployeeModel> GetAllActive();
        void Add(EmployeeModel task);
        void Update(int taskId, EmployeeModel task);
        void Delete(int taskId);
    }
}
