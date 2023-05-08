using Microsoft.AspNetCore.Mvc;

namespace ObraFacilApp.Controllers
{
    public class LogarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
