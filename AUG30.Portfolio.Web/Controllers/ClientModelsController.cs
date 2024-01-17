using AUG30.Portfolio.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUG30.Portfolio.Web.Controllers
{
    [Authorize(Roles = "ClientModels")]
    public class ClientModelsController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ClientModelsController(MyDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: ClientModelsController
        public ActionResult Index()
        {
            ViewData["message"] = "Welcome to index page";
            var data = _context.ClientModel.ToList();
            return View(data);
        }

        // GET: ClientModelsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientModelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientModelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CLientModel model, IFormFile PhotoUrl)
        {
            try
            {
                string filePath = "";
                if (PhotoUrl.Length > 0)
                {
                    string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    filePath = Path.Combine(uploads, PhotoUrl.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        PhotoUrl.CopyTo(fileStream);
                    }
                }
                if (ModelState.IsValid)
                {
                    model.PhotoUrl = "/uploads/" + PhotoUrl.FileName;
                    _context.ClientModel.Add(model);
                    int result = _context.SaveChanges();
                    if (result > 0)
                    {
                        TempData["message"] = "Data Inserted Successfully...!!!";

                        return RedirectToAction(nameof(Index));
                    }


                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ClientModelsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientModelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientModelsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientModelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
