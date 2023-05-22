﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class LogarController : Controller
    {
        private readonly Contexto _context;

        public LogarController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Logar dadosLogin)
        {
            if (ModelState.IsValid)
            {
                if (dadosLogin == null || _context.Login == null)
                    return NotFound();

                var login = await _context.Login
                    .FirstOrDefaultAsync(m => m.UserName == dadosLogin.UserName
                                              && m.Senha == dadosLogin.Senha);

                if (login == null)
                { 
                    ModelState.AddModelError("", "Usuário ou senha incorretos."); // Adiciona mensagem de erro à ModelState
                    return View(); // Retorna a view com a mensagem de erro
                }
            else
                return LocalRedirect("/Home");
            }
            return View();
        }
    }
}