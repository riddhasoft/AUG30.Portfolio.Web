using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AUG30.Portfolio.Web.Controllers
{
    public class ClientMessageController : Controller
    {
        private readonly MyDbContext _context;

        public ClientMessageController(MyDbContext context)
        {
            _context = context;
        }
        // GET: ClientMessageController
        public ActionResult Index()
        {
            var model = _context.ClientMessageModel.Include(x => x.CLient).ToList();
            return View(model);
        }

        // GET: ClientMessageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientMessageController/Create
        public ActionResult Create()
        {
           
           
            var selectList= new SelectList(_context.ClientModel, "Id", "FullName");
            ViewData["ClientId"] = selectList;
            return View();
        }

        // POST: ClientMessageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ClientMessageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientMessageController/Edit/5
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

        // GET: ClientMessageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientMessageController/Delete/5
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
