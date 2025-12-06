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
            var q = await _userService.GetAllAsync();
            var userList = await _userService.GetAllPublicIdAsync();
            ViewBag.UserList = "[";
            foreach(var u in userList)
            {

                ViewBag.UserList += $"'{u}'"+",";
            }
            var a = "";
            a = ViewBag.UserList;
            var i = a.Length;
            ViewBag.UserList=a.Substring(0, i - 1);
            //Console.WriteLine(a);
            //ViewBag.UserList.Substring(0, i-5);
            ViewBag.UserList += "]";

            return View(q);
        }
        public IActionResult Index()
        {return View();}

        public IActionResult Privacy()
        {return View();}
        [HttpPost]
        public async Task<IActionResult> Users(List<string> name) 
        {

            var userList = await _userService.GetAllPublicIdAsync();
            ViewBag.UserList = userList.ToList();
            //ViewBag.List = new List<string>();
            //Console.WriteLine(name.GetType());
            //Console.WriteLine("-----------------asd----------------------asd----------------------asd------------------");
            foreach (var user in name) {
                var a=user.Split(",");
                foreach(var i in a)
                {
                    //Console.WriteLine(i);
                    await _userService.DeleteAsync(new Guid(i));
                }
            }
            //await _userService.DeleteAsync(name);
            return RedirectToAction("Users");
        }
        public async Task<IActionResult> User(Guid userPublicID)//userDetail
        {
            var user = await _userService.GetByPublicIIdAsync(userPublicID);
            var a = new UserEntity()
            {
                Id = user.Id,
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Emil
            };
            return View(a);
        }
        public async Task<IActionResult> MakeUser() {
            return View(new cREATEuSERModel());
        }
        [HttpPost]
        public async Task<IActionResult> MakeUser(cREATEuSERModel us)
        {            
            var ot= 0; var q=new UserDTO();
            var userList = await _userService.GetAllAsync();
            foreach (var user in userList) { if (ot < user.Id) { ot = user.Id; } }
            if (us == null || us.Name == "" || us.Email == "" || us.Name == null || us.Email == null)
            { q = new UserDTO() { Name = "wh", Emil = "q@q.q", Id = ot + 1, PublicId = Guid.NewGuid() }; }
            else { q = new UserDTO() { Name = us.Name, Emil = us.Email, Id = ot + 1, PublicId = Guid.NewGuid() }; }
            await _userService.CreateAsync(q);
            return RedirectToAction("Users");
        }
        public async Task<IActionResult> Update(Guid userPublicID) 
        {            
            var user = await _userService.GetByPublicIIdAsync(userPublicID);
            return View(new UpdateModel() { PublicId=userPublicID,Email=user.Emil});
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateModel model)
        {
            if (model == null || model.Email == "" || model.Email == null )
            {
                model = new UpdateModel() { PublicId = model.PublicId, Email = "qq@qq.qq" };
            }
            var us = await _userService.GetByPublicIIdAsync(model.PublicId);
            var n = new UserDTO() {
                Id=us.Id,
                Emil=model.Email,
                Name=us.Name,
                PublicId=us.PublicId
            };
            await _userService.UpdateAsync(n);
            return RedirectToAction("Users");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
