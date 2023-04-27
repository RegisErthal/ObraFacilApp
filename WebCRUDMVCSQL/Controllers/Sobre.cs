using Microsoft.AspNetCore.Mvc;

namespace ObraFacilApp.Controllers
{
    public class Sobre : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
