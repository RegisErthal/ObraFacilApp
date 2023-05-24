using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly ContextoModel _context;

        public ProjetosController(ContextoModel context)
        {
            _context = context;
        }

        // GET: Projetoe
        public async Task<IActionResult> Index()
        {
            return _context.Projeto_1 != null ?
                        View(await _context.Projeto_1.ToListAsync()) :
                        Problem("Entity set 'Contexto.Projeto_1'  is null.");
        }

        // GET: Projetoe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projeto_1 == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetoe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projetoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProjeto,Responsavel,EmailResponsavel,CustoMetro,DataInicio,DataConclusao")] ProjetoModel projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetoe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projeto_1 == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto_1.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        // POST: Projetoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProjeto")] ProjetoModel projeto)
        {
            if (id != projeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.Id))
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
            return View(projeto);
        }

        // GET: Projetoe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projeto_1 == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projeto_1 == null)
            {
                return Problem("Entity set 'Contexto.Projeto_1'  is null.");
            }
            var projeto = await _context.Projeto_1.FindAsync(id);
            if (projeto != null)
            {
                _context.Projeto_1.Remove(projeto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return (_context.Projeto_1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
