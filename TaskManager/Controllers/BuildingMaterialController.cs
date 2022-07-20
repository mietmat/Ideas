using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class BuildingMaterialController : Controller
    {
        private readonly IBuildingMaterialRepository _buildingMaterialRepository;

        public BuildingMaterialController(IBuildingMaterialRepository buildingMaterialRepository)
        {
            _buildingMaterialRepository = buildingMaterialRepository;
        }
        // GET: BuildingMaterialController
        public ActionResult Index()
        {

            return View(_buildingMaterialRepository.GetAllActive());
        }

        // GET: BuildingMaterialController/Details/5
        public ActionResult Details(int id)
        {
            return View(_buildingMaterialRepository.Get(id));
        }

        // GET: BuildingMaterialController/Create
        public ActionResult Create()
        {
            return View(new BuildingMaterialModel());
        }

        // GET:       
        public ActionResult DeleteAll()
        {
            return View();
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAll(BuildingMaterialModel buildingMaterialModel)
        {
            _buildingMaterialRepository.DeleteAll();
            return RedirectToAction(nameof(Index));

        }

        // POST: BuildingMaterialController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuildingMaterialModel buildingMaterialModel)
        {
            _buildingMaterialRepository.Add(buildingMaterialModel);

            return RedirectToAction(nameof(Index));

        }

        // GET: BuildingMaterialController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_buildingMaterialRepository.Get(id));
        }

        // POST: BuildingMaterialController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BuildingMaterialModel buildingMaterialModel)
        {
            _buildingMaterialRepository.Update(id, buildingMaterialModel);
            return RedirectToAction(nameof(Index));

        }

        // GET: BuildingMaterialController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_buildingMaterialRepository.Get(id));

        }

        // POST: BuildingMaterialController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BuildingMaterialModel buildingMaterialModel)
        {
            _buildingMaterialRepository.Delete(id);

            return RedirectToAction(nameof(Index));

        }

        //GET: Task/Done/5
        public ActionResult Done(int id)
        {
            BuildingMaterialModel buildingMaterial = _buildingMaterialRepository.Get(id);
            buildingMaterial.Done = true;

            _buildingMaterialRepository.Update(id, buildingMaterial);

            return RedirectToAction(nameof(Index));
        }
    }
}
