using Microsoft.AspNetCore.Mvc;

namespace ObraFacilApp.Controllers
{
    public class MeuContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
