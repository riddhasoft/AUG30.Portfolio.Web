using AUG30.Portfolio.Model;
using Microsoft.AspNetCore.Mvc;

namespace AUG30.Portfolio.Web.Controllers
{
    public class AdminController : Controller
    {
        
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
