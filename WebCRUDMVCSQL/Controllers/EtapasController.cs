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
            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);

            var fundacao = _context.Fundacao?.FirstOrDefault(m => m.ProjetoId == id);
            var alvenaria = _context.Alvenaria?.FirstOrDefault(m => m.ProjetoId == id);
            var cobertura = _context.Cobertura?.FirstOrDefault(m => m.ProjetoId == id);
            var eletrica = _context.Eletrica?.FirstOrDefault(m => m.ProjetoId == id);
            var hidraulica = _context.Hidraulica?.FirstOrDefault(m => m.ProjetoId == id);

            decimal percFundacaoOk = QtdOkFundacao(fundacao);
            decimal percAlvenariaOk = QtdOkAlvenaria(alvenaria);
            decimal percCoberturaOk = QtdOkCobertura(cobertura);
            decimal percEletricaOk = QtdOkEletrica(eletrica);
            decimal percHidraulicaOk = QtdOkHidraulica(hidraulica);

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

        private static decimal QtdOkFundacao(FundacaoModel? fundacaoExistente)
        {
            var contFundacaoOk = 0;

            if (fundacaoExistente?.AlicerceOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.QtdBlocosAlicerceOK ?? false)
                contFundacaoOk++;


            if (fundacaoExistente?.IpermeabilizacaoVigaBaldrameOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.VigaBaldrameOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.QtdMicroOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.DataInicioFundacaoOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.DataInicioFundacaoOK ?? false)
                contFundacaoOk++;

            return (contFundacaoOk * 100) / 7;
        }

        private static decimal QtdOkAlvenaria(AlvenariaModel? alvenariaModel)
        {
            var contAlvenariaOk = 0;

            if (alvenariaModel?.MetrosDeParedeOK ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.QtdBlocosOk ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.QtdPilaresOk ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.DataInicioAlvenariaOk ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.DataConclusaoAlvenariaOk ?? false)
                contAlvenariaOk++;


            return (contAlvenariaOk * 100) / 5;
        }

        private static decimal QtdOkCobertura(CoberturaModel? cobertura)
        {
            var ret = 0;

            if (cobertura?.TamanhoCoberturaOK ?? false)
                ret++;

            if (cobertura?.MetragemCubicaLageOk ?? false)
                ret++;

            //if (cobertura?.EspeEspessuraLajeOK ?? false)
            //    ret++;

            if (cobertura?.DataInicioCoberturaOK ?? false)
                ret++;

            if (cobertura?.DataConclusaoCoberturaOK ?? false)
                ret++;


            return (ret * 100) / 4;
        }

        private static decimal QtdOkEletrica(EletricaModel? eletrica)
        {
            var ret = 0;

            if (eletrica?.LigacaoMonofasicaOk ?? false)
                ret++;

            if (eletrica?.LigacaoTrifasicaOk ?? false)
                ret++;

            if (eletrica?.QtdDisjuntoresOk ?? false)
                ret++;

            if (eletrica?.QtdTomadasOk ?? false)
                ret++;

            if (eletrica?.QtdLampadasOk ?? false)
                ret++;

            if (eletrica?.DataInicioEletricaOk ?? false)
                ret++;

            if (eletrica?.DataConclusaoEletricaOk ?? false)
                ret++;


            return (ret * 100) / 7;
        }

        private static decimal QtdOkHidraulica(HidraulicaModel? hidraulica)
        {
            var ret = 0;

            if (hidraulica?.QtdTorneirasOK ?? false)
                ret++;

            if (hidraulica?.QtdRalosOK ?? false)
                ret++;

            if (hidraulica?.QtdRegistrosOk ?? false)
                ret++;

            if (hidraulica?.DataInicioHidraulicaOK ?? false)
                ret++;

            if (hidraulica?.DataConclusaoHidraulicaOK ?? false)
                ret++;

            if (hidraulica?.QtdCaixaGorduraOk ?? false)
                ret++;


            return (ret * 100) / 4;
        }

    }
}
