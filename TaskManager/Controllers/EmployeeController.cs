using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(_employeeRepository.GetAllActive());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_employeeRepository.Get(id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            _employeeRepository.Add(employeeModel);

            return RedirectToAction(nameof(Index));

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_employeeRepository.Get(id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeModel employeeModel)
        {
            _employeeRepository.Update(id, employeeModel);

            return RedirectToAction(nameof(Index));

        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_employeeRepository.Get(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeModel employeeModel)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction(nameof(Index));

        }

        //GET: Task/Done/5
        public ActionResult Done(int id)
        {
            EmployeeModel employee = _employeeRepository.Get(id);
            employee.Done = true;

            _employeeRepository.Update(id, employee);

            return RedirectToAction(nameof(Index));
        }
    }
}
