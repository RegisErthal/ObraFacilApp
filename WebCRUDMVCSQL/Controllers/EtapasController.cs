using Microsoft.AspNetCore.Mvc;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class EtapasController : Controller
    {
        public IActionResult Index(int id)
        {
            var model = new ProjetoModel();
            model.Id = id;
            return View(model);
        }
    }
}
