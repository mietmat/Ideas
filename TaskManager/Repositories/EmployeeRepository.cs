using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TaskManagerContext _context;
        public EmployeeRepository(TaskManagerContext context)
        {
            _context = context;
        }
        public EmployeeModel Get(int employeeId)
        {
            return _context.Employees.SingleOrDefault(x => x.Id == employeeId);
        }

        public IQueryable<EmployeeModel> GetAllActive()
        {
            return _context.Employees.Where(x => !x.Done);
        }

        public void Add(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(int employeeId, EmployeeModel employee)
        {
            var result = _context.Employees.SingleOrDefault(x => x.Id == employeeId);
            if (result != null)
            {
                result.Name = employee.Name;
                result.Surname = employee.Surname;
                result.Age = employee.Age;
                result.Position = employee.Position;
                result.YearsOfExperience = employee.YearsOfExperience;
                result.Done = employee.Done;
            }
            _context.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var result = _context.Employees.SingleOrDefault(x => x.Id == employeeId);

            if (result != null)
            {
                _context.Employees.Remove(result);
                _context.SaveChanges();
            }


        }
    }
}
