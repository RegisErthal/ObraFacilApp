using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Migrations;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class CoberturaController : Controller
    {
        private readonly ContextoModel _context;

        public CoberturaController(ContextoModel context)
        {
            _context = context;
        }

        // GET: Cobertura
        public async Task<IActionResult> Index()
        {
              return _context.Cobertura != null ? 
                          View(await _context.Cobertura.ToListAsync()) :
                          Problem("Entity set 'Contexto.Cobertura'  is null.");
        }

        // GET: Cobertura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobertura == null)
            {
                return NotFound();
            }

            var cobertura = await _context.Cobertura
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (cobertura == null)
            {
                return NotFound();
            }

            return View(cobertura);
        }

        // GET: Cobertura/Create
        public IActionResult Create([FromRoute] int id)
        {
            var CoberturaExistente  = _context.Cobertura.FirstOrDefault(m => m.ProjetoId == id);
            if (CoberturaExistente == null)
            {
                ViewBag.Id = id;
                return View();
            }
            else
            {
                return Redirect("/Cobertura/Details/" + CoberturaExistente.ProjetoId);
            }
        }

        // POST: Cobertura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ProjetoId, [Bind("ProjetoId,TamanhoCobertura,PossueLaje,EspessuraLaje,DataInicioCobertura,DataConclusaoCobertura,TamanhoCoberturaOK,MetragemCubicaLageOk,DataInicioCoberturaOK,DataConclusaoCoberturaOK")] CoberturaModel cobertura)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            cobertura.ProjetoId = ProjetoId;
            if (ModelState.IsValid)
            {
                _context.Entry(cobertura).State = EntityState.Added;
                _context.Add(cobertura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/Cobertura/Details/" + cobertura.ProjetoId);
        }

        // GET: Cobertura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cobertura == null)
            {
                return NotFound();
            }

            var CoberturaExistente = _context.Cobertura.FirstOrDefault(m => m.ProjetoId == id);
            if (CoberturaExistente == null)
            {
                return NotFound();
            }
            return View(CoberturaExistente);
        }

        // POST: Cobertura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjetoId,TamanhoCobertura,PossueLaje,EspessuraLaje,DataInicioCobertura,DataConclusaoCobertura,TamanhoCoberturaOK,MetragemCubicaLageOk,DataInicioCoberturaOK,DataConclusaoCoberturaOK")] CoberturaModel cobertura)
        {
            if (id != cobertura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobertura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoberturaExists(cobertura.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Cobertura/Details/" + cobertura.ProjetoId);
            }
            return Redirect("/Cobertura/Details/" + cobertura.ProjetoId);
        }

        // GET: Cobertura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cobertura == null)
            {
                return NotFound();
            }

            var cobertura = await _context.Cobertura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobertura == null)
            {
                return NotFound();
            }

            return View(cobertura);
        }

        // POST: Cobertura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cobertura == null)
            {
                return Problem("Entity set 'Contexto.Cobertura'  is null.");
            }
            var cobertura = await _context.Cobertura.FindAsync(id);
            if (cobertura != null)
            {
                _context.Cobertura.Remove(cobertura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoberturaExists(int id)
        {
          return (_context.Cobertura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
