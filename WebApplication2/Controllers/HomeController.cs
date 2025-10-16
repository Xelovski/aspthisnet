using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Datalayer;
using WebApplication2.Datalayer.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context= context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Users()
        {
            var userList = _context.Users.ToList();
            return View(userList);
        }
        public IActionResult User(Guid userPublicID)//userDetail
        {
            var user = _context.Users.FirstOrDefault(u=>u.PublicId==userPublicID);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
