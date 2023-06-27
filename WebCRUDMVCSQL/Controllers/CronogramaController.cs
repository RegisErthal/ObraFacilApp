using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Migrations;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class CronogramaController : Controller
    {
        private readonly ContextoModel _context;

        public CronogramaController(ContextoModel context)
        {
            _context = context;
        }

        // GET: Cronograma
        public async Task<IActionResult> Index()
        {
              return _context.Cronograma != null ? 
                          View(await _context.Cronograma.ToListAsync()) :
                          Problem("Entity set 'Contexto.Cronograma'  is null.");
        }

        // GET: Cronograma/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Fundacao == null) {
                return NotFound();
            }

            var fundacao = await _context.Fundacao
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (fundacao == null) {
                return NotFound();
            }

            if (id == null || _context.Alvenaria == null) {
                return NotFound();
            }

            var alvenaria = await _context.Alvenaria
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (alvenaria == null) {
                return NotFound();
            }

            if (id == null || _context.Cobertura == null) {
                return NotFound();
            }

            var cobertura = await _context.Cobertura
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (cobertura == null) {
                return NotFound();
            }

            if (id == null || _context.Eletrica == null) {
                return NotFound();
            }

            var eletrica = await _context.Eletrica
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (eletrica == null) {
                return NotFound();
            }

            if (id == null || _context.Hidraulica == null) {
                return NotFound();
            }

            var hidraulica = await _context.Hidraulica
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (hidraulica == null) {
                return NotFound();
            }

            List<CronogramaViewModel> cronogramaViewModels = new List<CronogramaViewModel>();
            cronogramaViewModels.Add(new CronogramaViewModel {
                NomeEtapa = "Fundacao",
                DataInicio = fundacao.DataInicioFundacao,
                DataFim = fundacao.DataConclusaoFundacao,
                DataInicioOk = fundacao.DataInicioFundacaoOK,
                DataFimOk = fundacao.DataConclusaoFundacaoOK
            });

            cronogramaViewModels.Add(new CronogramaViewModel {
                NomeEtapa = "Alvenaria",
                DataInicio = alvenaria.DataInicioAlvenaria,
                DataFim = alvenaria.DataConclusaoAlvenaria,
                DataInicioOk = alvenaria.DataInicioAlvenariaOk,
                DataFimOk = alvenaria.DataConclusaoAlvenariaOk
            });

            cronogramaViewModels.Add(new CronogramaViewModel {
                NomeEtapa = "Cobertura",
                DataInicio = cobertura.DataInicioCobertura,
                DataFim = cobertura.DataConclusaoCobertura,
                DataInicioOk = cobertura.DataInicioCoberturaOK,
                DataFimOk = cobertura.DataConclusaoCoberturaOK
            });

            cronogramaViewModels.Add(new CronogramaViewModel {
                NomeEtapa = "Eletrica",
                DataInicio = eletrica.DataInicioEletrica,
                DataFim = eletrica.DataConclusaoEletrica,
                DataInicioOk = eletrica.DataInicioEletricaOk,
                DataFimOk = eletrica.DataConclusaoEletricaOk
            });

            cronogramaViewModels.Add(new CronogramaViewModel {
                NomeEtapa = "Hidraulica",
                DataInicio = hidraulica.DataInicioHidraulica,
                DataFim = hidraulica.DataConclusaoHidraulica,
                DataInicioOk = hidraulica.DataInicioHidraulicaOK,
                DataFimOk = hidraulica.DataConclusaoHidraulicaOK
            });

            return View(cronogramaViewModels);

        }

        // GET: Cronograma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cronograma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataInicioFundacao,DataInicioFundacaoOk,DataConclusaoFundacao,DataConclusaoFundacaoOk,DataConclusaoAlvenaria,DataConclusaoAlvenariaOk,DataInicioCobertura,DataInicioCoberturaOk,DataConclusaoCobertura,DataInicioEletrica,DataInicioEletricaOk,DataConclusaoEletrica,DataConclusaoEletricaOk,DataInicioHidraulica,DataInicioHidraulicaOk,DataConclusaoHidraulica,DataConclusaoHidraulicaOk")] CronogramaModel cronograma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cronograma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cronograma);
        }

        // GET: Cronograma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cronograma == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronograma.FindAsync(id);
            if (cronograma == null)
            {
                return NotFound();
            }
            return View(cronograma);
        }

        // POST: Cronograma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataInicioFundacao,DataInicioFundacaoOk,DataConclusaoFundacao,DataConclusaoFundacaoOk,DataConclusaoAlvenaria,DataConclusaoAlvenariaOk,DataInicioCobertura,DataInicioCoberturaOk,DataConclusaoCobertura,DataInicioEletrica,DataInicioEletricaOk,DataConclusaoEletrica,DataConclusaoEletricaOk,DataInicioHidraulica,DataInicioHidraulicaOk,DataConclusaoHidraulica,DataConclusaoHidraulicaOk")] CronogramaModel cronograma)
        {
            if (id != cronograma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cronograma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CronogramaExists(cronograma.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cronograma);
        }

        // GET: Cronograma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cronograma == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronograma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cronograma == null)
            {
                return NotFound();
            }

            return View(cronograma);
        }

        // POST: Cronograma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cronograma == null)
            {
                return Problem("Entity set 'Contexto.Cronograma'  is null.");
            }
            var cronograma = await _context.Cronograma.FindAsync(id);
            if (cronograma != null)
            {
                _context.Cronograma.Remove(cronograma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CronogramaExists(int id)
        {
          return (_context.Cronograma?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
