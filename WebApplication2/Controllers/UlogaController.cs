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
        public IActionResult Uloha5()
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
                },
                new Useri()
                {
                    Name="Steph"
                    ,Email="seph@special.com"
                    ,Password="1sd4"
                    ,Username="StepS"
                }
                ,new Useri()
                {
                    Name="someoneElse"
                    ,Email="someone@else.com"
                    ,Password="4"
                    ,Username="Heeeeeeeee"
                }
            };
            return View(users);
        }
    }
}
