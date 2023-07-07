using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Migrations;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class EletricaController : Controller
    {
        private readonly ContextoModel _context;

        public EletricaController(ContextoModel context)
        {
            _context = context;
        }

        // GET: Eletrica
        public async Task<IActionResult> Index()
        {
              return _context.Eletrica != null ? 
                          View(await _context.Eletrica.ToListAsync()) :
                          Problem("Entity set 'Contexto.Eletrica'  is null.");
        }

        // GET: Eletrica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eletrica == null)
            {
                return NotFound();
            }

            var eletrica = await _context.Eletrica
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (eletrica == null)
            {
                return NotFound();
            }

            return View(eletrica);
        }

        // GET: Eletrica/Create
        public IActionResult Create([FromRoute] int id)
        {
            var EletricaExistente = _context.Eletrica.FirstOrDefault(m => m.ProjetoId == id);
            if (EletricaExistente == null)
            {
                ViewBag.Id = id;
                return View();
            }
            else
            {
                return Redirect("/Eletrica/Details/" + EletricaExistente.ProjetoId);
            }
        }

        // POST: Eletrica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ProjetoId,[Bind("ProjetoId,LigacaoMonofasica,LigacaoTrifasica,QtdDisjuntores,QtdTomadas,QtdLampadas,DataInicioEletrica,DataConclusaoEletrica,PrevisaoCusto")] EletricaModel eletrica)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            eletrica.ProjetoId = ProjetoId;
            if (ModelState.IsValid)
            {
                _context.Entry(eletrica).State = EntityState.Added;
                _context.Add(eletrica);
                await _context.SaveChangesAsync();
                return Redirect("/Eletrica/Details/" + eletrica.ProjetoId);
            }
            return Redirect("/Eletrica/Details/" + eletrica.ProjetoId);
        }

        // GET: Eletrica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eletrica == null)
            {
                return NotFound();
            }

            var EletricaExistente = _context.Eletrica.FirstOrDefault(m => m.ProjetoId == id);
            if (EletricaExistente == null)
            {
                return NotFound();
            }
            return View(EletricaExistente);
        }

        // POST: Eletrica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
               public async Task<IActionResult> Edit(int id, [Bind("Id,ProjetoId,LigacaoMonofasica,LigacaoTrifasica,QtdDisjuntores,QtdDisjuntoresOk,QtdTomadas,QtdTomadasOk,DataInicioEletrica,DataInicioEletricaOk,DataConclusaoEletrica,DataConclusaoEletricaOk,PrevisaoCusto")] EletricaModel eletrica) {
            if (id != eletrica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eletrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EletricaExists(eletrica.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Eletrica/Details/" + eletrica.ProjetoId);
            }
            return Redirect("/Eletrica/Details/" + eletrica.ProjetoId);
        }

        // GET: Eletrica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eletrica == null)
            {
                return NotFound();
            }

            var eletrica = await _context.Eletrica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eletrica == null)
            {
                return NotFound();
            }

            return View(eletrica);
        }

        // POST: Eletrica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eletrica == null)
            {
                return Problem("Entity set 'Contexto.Eletrica'  is null.");
            }
            var eletrica = await _context.Eletrica.FindAsync(id);
            if (eletrica != null)
            {
                _context.Eletrica.Remove(eletrica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EletricaExists(int id)
        {
          return (_context.Eletrica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
