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
    public class AlvenariaController : Controller
    {
        private readonly Contexto _context;

        public AlvenariaController(Contexto context)
        {
            _context = context;
        }

        // GET: Alvenaria
        public async Task<IActionResult> Index()
        {
              return _context.Alvenaria != null ? 
                          View(await _context.Alvenaria.ToListAsync()) :
                          Problem("Entity set 'Contexto.Alvenaria'  is null.");
        }

        // GET: Alvenaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alvenaria == null)
            {
                return NotFound();
            }

            var alvenaria = await _context.Alvenaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alvenaria == null)
            {
                return NotFound();
            }

            return View(alvenaria);
        }

        // GET: Alvenaria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alvenaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProjeto,QtdBlocos,AlturaBloco,ComprimentoBlocos,QtdPilares,DataInicioFundacao,DataConclusaoAlvenaria")] Alvenaria alvenaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alvenaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alvenaria);
        }

        // GET: Alvenaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alvenaria == null)
            {
                return NotFound();
            }

            var alvenaria = await _context.Alvenaria.FindAsync(id);
            if (alvenaria == null)
            {
                return NotFound();
            }
            return View(alvenaria);
        }

        // POST: Alvenaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProjeto,QtdBlocos,AlturaBloco,ComprimentoBlocos,QtdPilares,DataInicioFundacao,DataConclusaoAlvenaria")] Alvenaria alvenaria)
        {
            if (id != alvenaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alvenaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlvenariaExists(alvenaria.Id))
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
            return View(alvenaria);
        }

        // GET: Alvenaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alvenaria == null)
            {
                return NotFound();
            }

            var alvenaria = await _context.Alvenaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alvenaria == null)
            {
                return NotFound();
            }

            return View(alvenaria);
        }

        // POST: Alvenaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alvenaria == null)
            {
                return Problem("Entity set 'Contexto.Alvenaria'  is null.");
            }
            var alvenaria = await _context.Alvenaria.FindAsync(id);
            if (alvenaria != null)
            {
                _context.Alvenaria.Remove(alvenaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlvenariaExists(int id)
        {
          return (_context.Alvenaria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
