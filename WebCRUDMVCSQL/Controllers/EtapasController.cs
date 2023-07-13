using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class EtapasController : Controller
    {
        private readonly ContextoModel _context;

        public EtapasController(ContextoModel context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var session = HttpContext.Session.GetString("ObraFacilUsuario");

            if (session == null)
            {
                return RedirectToAction("Index", "Logar");
            }

            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);

            var fundacao = _context.Fundacao?.FirstOrDefault(m => m.ProjetoId == id);
            var alvenaria = _context.Alvenaria?.FirstOrDefault(m => m.ProjetoId == id);
            var cobertura = _context.Cobertura?.FirstOrDefault(m => m.ProjetoId == id);
            var eletrica = _context.Eletrica?.FirstOrDefault(m => m.ProjetoId == id);
            var hidraulica = _context.Hidraulica?.FirstOrDefault(m => m.ProjetoId == id);

            decimal percFundacaoOk = Utils.QtdOkFundacao(fundacao);
            decimal percAlvenariaOk = Utils.QtdOkAlvenaria(alvenaria);
            decimal percCoberturaOk = Utils.QtdOkCobertura(cobertura);
            decimal percEletricaOk = Utils.QtdOkEletrica(eletrica);
            decimal percHidraulicaOk = Utils.QtdOkHidraulica(hidraulica);

            var model = new EtapasModel();
            model.Id = id;

            model.FundacaoPerc = percFundacaoOk;
            model.AlvenariaPerc = percAlvenariaOk;
            model.CoberturaPerc = percCoberturaOk;
            model.EletricaPerc = percEletricaOk;
            model.HidraulicaPerc = percHidraulicaOk;

            model.TemFundacao = fundacao != null;
            model.TemAlvenaria = alvenaria != null;
            model.TemCobertura = cobertura != null;
            model.TemEletrica = eletrica != null;
            model.TemHidraulica = hidraulica != null;

            model.MostraCronograma = model.TemFundacao && model.TemAlvenaria && model.TemCobertura && model.TemEletrica && model.TemHidraulica;
            model.UsuarioIsAdmin = usuario.isAdmin;

            return View(model);
        }


    }
}
