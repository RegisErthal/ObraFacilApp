using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ObraFacilApp.Models;


namespace ObraFacilApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();                      
        }

        public IActionResult Logar(string username, string senha ) 
        {
            return Json(new {});
        }

    }
}


