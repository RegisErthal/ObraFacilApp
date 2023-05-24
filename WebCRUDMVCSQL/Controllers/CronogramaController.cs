using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Details(int? id)
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
