using AUG30.Portfolio.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AUG30.Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly MyDbContext _context;
        public HomeController( MyDbContext context)
        { 
            _context = context;
        }

        public IActionResult Index()
        {
            ProfileModel model = _context.ProfileModel.FirstOrDefault();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}