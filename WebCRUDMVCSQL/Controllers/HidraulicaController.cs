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
    public class HidraulicaController : Controller
    {
        private readonly Contexto _context;

        public HidraulicaController(Contexto context)
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hidraulica == null)
            {
                return NotFound();
            }

            return View(hidraulica);
        }

        // GET: Hidraulica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hidraulica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProjeto,QtdTorneiras,QtdRalos,DataInicioEletrica,DataConclusaoEletrica")] Hidraulica hidraulica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hidraulica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hidraulica);
        }

        // GET: Hidraulica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hidraulica == null)
            {
                return NotFound();
            }

            var hidraulica = await _context.Hidraulica.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProjeto,QtdTorneiras,QtdRalos,DataInicioEletrica,DataConclusaoEletrica")] Hidraulica hidraulica)
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
                return RedirectToAction(nameof(Index));
            }
            return View(hidraulica);
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
