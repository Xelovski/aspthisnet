using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UlogaController : Controller
    {
        public IActionResult Uloha()
        {
            return View();
        }
        public IActionResult Uloha2()
        {
            return View();
        }
        public IActionResult Uloha3()
        {
            return View();
        }
        public IActionResult Uloha4()
        {
            List<Useri> users = new List<Useri>()
            {
                new Useri() {
                    Name = "TesN",
                    Email = "Test@",
                    Password = "12345",
                    Username = "TestUn",
                },
                new Useri() {
                    Name = "TesN1",
                    Email = "Test@1",
                    Password = "123451",
                    Username = "TestUn1",
                }
            };
            return View(users);
        }
    }
}
