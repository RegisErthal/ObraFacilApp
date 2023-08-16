using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObraFacilApp.Models;
using System.Threading.Tasks;

namespace ObraFacilApp.Controllers
{
    public class LogarController : Controller
    {
        private readonly ContextoModel _context;

        public LogarController(ContextoModel context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Adiciona proteção CSRF
        public async Task<IActionResult> Login(LogarModel dadosLogin) {
            if (ModelState.IsValid) {
                var login = await _context.Login
                    .FirstOrDefaultAsync(m => m.UserName == dadosLogin.UserName
                                              && m.Senha == dadosLogin.Senha);

                if (login == null) {
                    ModelState.AddModelError("", "Usuário ou senha incorretos.");
                    return View("Index", dadosLogin); // Retorna para a view com os dados de login e a mensagem de erro
                } else {
                    HttpContext.Session.SetString("ObraFacilUsuario", JsonConvert.SerializeObject(login));
                    return LocalRedirect("/Home");
                }
            }

            return View("Index", dadosLogin); // Retorna para a view com os dados de login
        }
    }
}
