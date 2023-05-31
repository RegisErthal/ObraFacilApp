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
    public class FundacaoController : Controller
    {
        private readonly ContextoModel _context;

        public FundacaoController(ContextoModel context)
        {
            _context = context;
        }

        // GET: Fundacao
        public async Task<IActionResult> Index()
        {
            return _context.Fundacao != null ?
                        View(await _context.Fundacao.ToListAsync()) :
                        Problem("Entity set 'Contexto.Fundacao'  is null.");
        }

        // GET: Fundacao/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Fundacao == null)
            {
                return NotFound();
            }

            var fundacao = await _context.Fundacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundacao == null)
            {
                return NotFound();
            }

            return View(fundacao);
        }

        // GET: Fundacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fundacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ProjetoId,[Bind("Id,ProjetoId,ComprimentoAlicerce,AlturaAlicerce,QtdBlocosAlicerce,AlturaPedra,ComprimentoPedra,AlturaVigaBaldrame,ComprimentoVigaBaldrame,LarguraVigaBaldrame,MetragemCubicaCimentoVigaBaldrama,QtdMicro,DataInicioFundacao,DataConclusaoFundacao")] FundacaoModel fundacao)
            {
            //if (id == null)
            //    throw new ArgumentNullException("id");
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            //fundacao.ProjetoId = id;

            if (ModelState.IsValid)
            {

                _context.Entry(fundacao).State = EntityState.Added;
                _context.Add(fundacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundacao);
        }

        // GET: Fundacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fundacao == null)
            {
                return NotFound();
            }

            var fundacao = await _context.Fundacao.FindAsync(id);
            if (fundacao == null)
            {
                return NotFound();
            }
            return View(fundacao);
        }

        // POST: Fundacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ComprimentoAlicerce,AlturaAlicerce,QtdBlocosAlicerce,AlturaPedra,ComprimentoPedra,AlturaVigaBaldrame,ComprimentoVigaBaldrame,LarguraVigaBaldrame,MetragemCubicaCimentoVigaBaldrama,QtdMicro,DataInicioFundacao,DataConclusaoFundacao")] FundacaoModel fundacao)
        {
            if (id != fundacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundacaoExists(fundacao.Id))
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
            return View(fundacao);
        }

        // GET: Fundacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fundacao == null)
            {
                return NotFound();
            }

            var fundacao = await _context.Fundacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundacao == null)
            {
                return NotFound();
            }

            return View(fundacao);
        }

        // POST: Fundacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fundacao == null)
            {
                return Problem("Entity set 'Contexto.Fundacao'  is null.");
            }
            var fundacao = await _context.Fundacao.FindAsync(id);
            if (fundacao != null)
            {
                _context.Fundacao.Remove(fundacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundacaoExists(int id)
        {
            return (_context.Fundacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
