using System.Diagnostics;
using BussinessLayer.Interfaces.Services;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Datalayer;
using WebApplication2.Datalayer.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        //----------------------------------------------------------------
        private static List<UserDTO> _users = new List<UserDTO>();
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, AppDbContext context,IUserService usS)
        {
            _context= context;
            _logger = logger;
            _userService= usS;
        }

        public async Task<IActionResult> Users()
        {
            var userList = await _userService.GetAllAsync();
            return View(userList);
        }//-------------------------------------------------------
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Users(Guid name) 
        {
            var us = _context.Users.FirstOrDefault(u => u.PublicId == name);
            _context.Users.Remove(us);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }
        public IActionResult User(Guid userPublicID)//userDetail
        {
            var user = _context.Users.FirstOrDefault(u=>u.PublicId==userPublicID);
            return View(user);
        }
        public async Task<IActionResult> MakeUser() {
            return View(new cREATEuSERModel());
        }
        [HttpPost]
        public IActionResult MakeUser(cREATEuSERModel us)
        {
            if (us == null||us.Name==""||us.Email==""||us.Name==null||us.Email==null) 
            { 
                us = new cREATEuSERModel() { Name = "wh", Email = "q@q.q" }; 
            }
            _context.Users.Add(new UserEntity() { Name=us.Name,Email=us.Email,PublicId=Guid.NewGuid()});
            _context.SaveChanges();
            return RedirectToAction("Users");
        }
        public IActionResult Update(Guid userPublicID) 
        {
            //Console.WriteLine(userPublicID);
            //Console.WriteLine(user.Email);
            var user = _context.Users.FirstOrDefault(u => u.PublicId == userPublicID);
            return View(new UpdateModel() { PublicId=userPublicID,Email=user.Email});
        }
        [HttpPost]
        public IActionResult Update(UpdateModel model)
        {
            if (model == null || model.Email == "" || model.Email == null )
            {
                model = new UpdateModel() { PublicId = model.PublicId, Email = "qq@qq.qq" };
            }
            Console.WriteLine(model.PublicId);
            var us = _context.Users.FirstOrDefault(u => u.PublicId == model.PublicId);
            _context.Users.Remove(us);
            _context.SaveChanges();
            _context.Users.Add(new UserEntity() {Id=us.Id, Name = us.Name, Email = model.Email, PublicId = model.PublicId });
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
