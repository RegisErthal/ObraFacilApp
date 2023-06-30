using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObraFacilApp.Models;

namespace ObraFacilApp.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly ContextoModel _context;

        public ProjetosController(ContextoModel context) {
            _context = context;
        }

        // GET: Projetoe
        public async Task<IActionResult> Index() {
            var session = HttpContext.Session.GetString("ObraFacilUsuario");
            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);

            var list = await _context.Projeto.ToListAsync();
            IEnumerable<ProjetoModel> listFiltered = null;

            if (usuario.isAdmin)
                listFiltered = list;
            else
                listFiltered = list.Where(x => x.UsuarioId == usuario.Id);

            var model = new TelaProjetosModel() {
                MostraBotaoCriar = usuario.isAdmin,
                Projetos = listFiltered,
            };

            return _context.Projeto != null ?
                        View(model) :
                        Problem("Entity set 'Contexto.Projeto_1'  is null.");
        }

        // GET: Projetoe/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Projeto == null) {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null) {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetoe/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Projetoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProjeto,Responsavel,EmailResponsavel,CustoMetro,DataInicio,DataConclusao")] ProjetoModel projeto) {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            //projeto.DataConclusao=DateTime.Now

            var session = HttpContext.Session.GetString("ObraFacilUsuario");
            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);

            if (ModelState.IsValid) {
                projeto.UsuarioId = usuario.Id;
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetoe/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Projeto == null) {
                return NotFound();
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto == null) {
                return NotFound();
            }
            return View(projeto);
        }

        // POST: Projetoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile uploadProjeto, [Bind("Id,NomeProjeto,Responsavel,EmailResponsavel,CustoMetro,DataInicio,DataConclusao")] ProjetoModel projeto) {
            if (id != projeto.Id) {
                return NotFound();
            }

            if (uploadProjeto == null || uploadProjeto.Length == 0)
                return BadRequest("No file selected");

            var fileName = Path.GetFileName(uploadProjeto.FileName);


            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Imagens", "UploadProjeto");


            if (!Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);


            using (var stream = new FileStream(filePath, FileMode.Create)) {
                await uploadProjeto.CopyToAsync(stream);
            }



            if (ModelState.IsValid) {
                try {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!ProjetoExists(projeto.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetoe/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Projeto == null) {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null) {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Projeto == null) {
                return Problem("Entity set 'Contexto.Projeto_1'  is null.");
            }
            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto != null) {
                _context.Projeto.Remove(projeto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id) {
            return (_context.Projeto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
