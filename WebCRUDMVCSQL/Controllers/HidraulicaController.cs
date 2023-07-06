using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class HidraulicaController : Controller
    {
        private readonly ContextoModel _context;

        public HidraulicaController(ContextoModel context)
        {
            _context = context;
        }

        // GET: Hidraulica
        public async Task<IActionResult> Index()
        {
              return _context.Hidraulica != null ? 
                          View(await _context.Hidraulica.ToListAsync()) :
                          Problem("Entity set 'Contexto.Hidraulica'  is null.");
        }

        // GET: Hidraulica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hidraulica == null)
            {
                return NotFound();
            }

            var hidraulica = await _context.Hidraulica
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (hidraulica == null)
            {
                return NotFound();
            }

            return View(hidraulica);
        }

        public IActionResult Create([FromRoute] int id)
        {
            var HidraulicaExistente = _context.Hidraulica.FirstOrDefault(m => m.ProjetoId == id);
            if (HidraulicaExistente == null)
            {
                ViewBag.Id = id;
                return View();
            }
            else
            {
                return Redirect("/Hidraulica/Details/" + HidraulicaExistente.ProjetoId);
            }
        }

        // POST: Hidraulica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ProjetoId,[Bind("ProjetoId,QtdTorneiras,QtdTorneirasOK,QtdRalosOKQtdRegistros,QtdRegistrosOk,QtdRalos,QtdRalosOK,QtdCaixaGordura,QtdCaixaGorduraOk,DataInicioHidraulicaOK,DataConclusaoHidraulicaOK,QtdRalos,DataInicioEletrica,DataConclusaoEletrica,PrevisaoCusto")] HidraulicaModel hidraulica)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            hidraulica.ProjetoId = ProjetoId;

            if (ModelState.IsValid)
            {
                _context.Entry(hidraulica).State = EntityState.Added;
                _context.Add(hidraulica);
                await _context.SaveChangesAsync();
                return Redirect("/Hidraulica/Details/" + hidraulica.ProjetoId);
            }
            return Redirect("/Hidraulica/Details/" + hidraulica.ProjetoId);
        }

        // GET: Hidraulica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hidraulica == null)
            {
                return NotFound();
            }

            var hidraulica = await _context.Hidraulica
                           .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (hidraulica == null)
            {
                return NotFound();
            }
            return View(hidraulica);
        }

        // POST: Hidraulica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjetoId,QtdTorneiras,QtdTorneirasOK,QtdRegistros,QtdRegistrosOk,QtdRalos,QtdRalosOK,QtdCaixaGordura,QtdCaixaGorduraOk,QtdRalosOK,DataInicioHidraulicaOK,DataConclusaoHidraulicaOK,QtdRalos,DataInicioEletrica,DataConclusaoEletrica,PrevisaoCusto")] HidraulicaModel hidraulica)
        {
            if (id != hidraulica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hidraulica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HidraulicaExists(hidraulica.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Hidraulica/Details/" + hidraulica.ProjetoId);
            }
            return Redirect("/Hidraulica/Details/" + hidraulica.ProjetoId);
        }

        // GET: Hidraulica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hidraulica == null)
            {
                return NotFound();
            }

            var hidraulica = await _context.Hidraulica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hidraulica == null)
            {
                return NotFound();
            }

            return View(hidraulica);
        }

        // POST: Hidraulica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hidraulica == null)
            {
                return Problem("Entity set 'Contexto.Hidraulica'  is null.");
            }
            var hidraulica = await _context.Hidraulica.FindAsync(id);
            if (hidraulica != null)
            {
                _context.Hidraulica.Remove(hidraulica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HidraulicaExists(int id)
        {
          return (_context.Hidraulica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
