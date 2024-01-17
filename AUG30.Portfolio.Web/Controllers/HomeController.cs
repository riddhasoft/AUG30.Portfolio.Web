using AUG30.Portfolio.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using AUG30.Portfolio.Service;

namespace AUG30.Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicesService _serviceService;
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
        private readonly IHomeService _homeService;

        public HomeController(IServicesService servicesService, IProfileService profileService, IUserService userService, IHomeService homeService)
        {
            _serviceService = servicesService;
            _profileService = profileService;
            _userService = userService;
            _homeService = homeService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.MyVariable = "hi this is message from viewBag";
            ProfileModel model = _profileService.Get().FirstOrDefault();
            List<ServiceModel> services = _serviceService.Get();
            List<CLientModel> clients = _homeService.GetCLients();

            PortfolioViewModel viewModel = new PortfolioViewModel()
            {
                ProfileModel = model,
                ServiceModels = services,
                Clients = clients,
            };
            // throw new Exception("this is the exception raised on action of the controller");
            return View(viewModel);
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = _userService.Get()
                                    .Where(x => x.Email == model.Username && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    addingClaimIdentity(model, user.Roles, user.FullName);

                    return Redirect("/admin");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Username or Password");
                    return View();
                }
            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Signup(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel()
                {
                    Email = model.Email,
                    Password = model.Password,
                    FullName = model.FullName,
                    Id = model.Id

                };
                _userService.Save(model);

                return RedirectToAction("Login");
            }
            return View();
        }
        private void addingClaimIdentity(LoginModel user, string roles, string fullname)
        {
            //list of claims
            var userClaims = new List<Claim>()
                {
                    new Claim("UserName", user.Username),
                    new Claim(ClaimTypes.Email,user.Username),
                    new Claim(ClaimTypes.Name,fullname),
                    new Claim("Mobile","9841235678"),
                    //new Claim(ClaimTypes.Role,"editor"),
                    
                 };

            foreach (var role in roles.Split(','))
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            //create a identity claims
            var claimsIdentity = new ClaimsIdentity(
            userClaims, CookieAuthenticationDefaults.AuthenticationScheme);


            //httcontext , current user is authentic user
            //sing in user to httpcontext
            HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity)
            );
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}