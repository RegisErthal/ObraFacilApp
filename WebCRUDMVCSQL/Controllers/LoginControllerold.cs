using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class LoginControllerold : Controller
    {
        private readonly Contexto _context;

        public LoginControllerold(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await _context.Login.ToListAsync();
            return View();
        }

        public IActionResult Logar(string username, string senha)
        {
            return Json(new { });
        }

    }
}


