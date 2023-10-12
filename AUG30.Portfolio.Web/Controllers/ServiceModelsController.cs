
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using AUG30.Portfolio.Model;
using Microsoft.AspNetCore.Authorization;
using AUG30.Portfolio.Service;

namespace AUG30.Portfolio.Web.Controllers
{
    [Authorize(Roles = "editor")]
    public class ServiceModelsController : Controller
    {
        private readonly IServicesService _service;

        public ServiceModelsController(IServicesService service)
        {
            
            _service = service;
        }

        // GET: ServiceModels
        public IActionResult Index()
        {
            return View(_service.Get());
        }

        // GET: ServiceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            var serviceModel = _service.Detail(id ?? 0);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // GET: ServiceModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                _service.Save(serviceModel);
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: ServiceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var serviceModel = _service.Detail(id ?? 0);
            if (serviceModel == null)
            {
                return NotFound();
            }
            return View(serviceModel);
        }

        // POST: ServiceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] ServiceModel serviceModel)
        {
            if (id != serviceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(serviceModel);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceModelExists(serviceModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: ServiceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            var serviceModel = _service.Detail(id ?? 0);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // POST: ServiceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var serviceModel = _service.Detail(id);
            if (serviceModel != null)
            {
                _service.Delete(id);
            }


            return RedirectToAction(nameof(Index));
        }

        private bool ServiceModelExists(int id)
        {
            return _service.Detail(id) != null;
        }
    }
}
