using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class ImagensController : Controller
    {
        private readonly ContextoModel _context;

        public ImagensController(ContextoModel context)
        {
            _context = context;
        }

        // GET: ImagensModel
        public async Task<IActionResult> Index()
        {
            return _context.Imagens != null ?
                        View(await _context.Imagens.ToListAsync()) :
                        Problem("Entity set 'ContextoModel.Imagens'  is null.");
        }

        // GET: ImagensModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Imagens == null)
            {
                return NotFound();
            }

            var imagensModel = await _context.Imagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagensModel == null)
            {
                return NotFound();
            }

            return View(imagensModel);
        }

        // GET: ImagensModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImagensModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEntidade,TiposEntidades,FileName,FilePath")] ImagensModel imagensModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imagensModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imagensModel);
        }

        // GET: ImagensModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Imagens == null)
            {
                return NotFound();
            }

            var imagensModel = await _context.Imagens.FindAsync(id);
            if (imagensModel == null)
            {
                return NotFound();
            }
            return View(imagensModel);
        }

        // POST: ImagensModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEntidade,TiposEntidades,FileName,FilePath")] ImagensModel imagensModel)
        {
            if (id != imagensModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagensModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagensModelExists(imagensModel.Id))
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
            return View(imagensModel);
        }

        // GET: ImagensModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Imagens == null)
            {
                return NotFound();
            }

            var imagensModel = await _context.Imagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagensModel == null)
            {
                return NotFound();
            }

            return View(imagensModel);
        }

        // POST: ImagensModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Imagens == null)
            {
                return Problem("Entity set 'ContextoModel.Imagens'  is null.");
            }

            var imagensModel = await _context.Imagens.FindAsync(id);
            if (imagensModel != null)
            {
                _context.Imagens.Remove(imagensModel);
            }

            await _context.SaveChangesAsync();

            var projetoId = 0;

            if (imagensModel.TiposEntidades == Models.Enum.TiposEntidadesEnum.Fundacao)
            {
                var etapa = await _context.Fundacao.FindAsync(imagensModel.IdEntidade);
                projetoId = etapa.ProjetoId ?? 0;
            }
            else if (imagensModel.TiposEntidades == Models.Enum.TiposEntidadesEnum.Alvenaria)
            {
                var etapa = await _context.Alvenaria.FindAsync(imagensModel.IdEntidade);
                projetoId = etapa.ProjetoId ?? 0;
            }
            else if (imagensModel.TiposEntidades == Models.Enum.TiposEntidadesEnum.Cobertura)
            {
                var etapa = await _context.Cobertura.FindAsync(imagensModel.IdEntidade);
                projetoId = etapa.ProjetoId ?? 0;
            }
            else if (imagensModel.TiposEntidades == Models.Enum.TiposEntidadesEnum.Eletrica)
            {
                var etapa = await _context.Eletrica.FindAsync(imagensModel.IdEntidade);
                projetoId = etapa.ProjetoId ?? 0;
            }
            else if (imagensModel.TiposEntidades == Models.Enum.TiposEntidadesEnum.Hidraulica)
            {
                var etapa = await _context.Hidraulica.FindAsync(imagensModel.IdEntidade);
                projetoId = etapa.ProjetoId ?? 0;
            }

            return Redirect("/Etapas/index/" + projetoId);
        }

        private bool ImagensModelExists(int id)
        {
            return (_context.Imagens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
