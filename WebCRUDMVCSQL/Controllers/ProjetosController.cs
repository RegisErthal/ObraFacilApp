using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using ObraFacilApp.Models;
using ObraFacilApp.Models.Enum;
using System.Web;

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
            var session = HttpContext.Session.GetString("ObraFacilUsuario");

            if (session == null)
            {
                return RedirectToAction("Index", "Logar");
            }

            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);

            var list = await _context.Projeto.ToListAsync();
            IEnumerable<ProjetoModel> listFiltered = null;

            if (usuario.isAdmin)
                listFiltered = list;
            else
                listFiltered = list.Where(x => x.UsuarioId == usuario.Id);

            var model = new TelaProjetosModel()
            {
                MostraBotaoCriar = usuario.isAdmin,
                Projetos = listFiltered,
            };

            return _context.Projeto != null ?
                        View(model) :
                        Problem("Entity set 'Contexto.Projeto_1'  is null.");
        }

        // GET: Projetoe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            var imagens = _context.Imagens.Where(m => m.IdEntidade == projeto.Id && m.TiposEntidades == TiposEntidadesEnum.Projeto).ToList();
            projeto.Imagens = imagens;

            return View(projeto);
        }

        // GET: Projetoe/Create
        public async Task<IActionResult> Create()
        {
            var usuarios = _context.Login.Select(c => new SelectListItem()
                                                    { Text = c.UserName, Value = c.Id.ToString() });

            ViewBag.UsuariosList = usuarios.ToList();
            return View();
        }

        // POST: Projetoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProjeto,UsuarioId,EmailResponsavel,CustoMetro,DataInicio,DataConclusao")] ProjetoModel projeto)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            //projeto.DataConclusao=DateTime.Now

            //var session = HttpContext.Session.GetString("ObraFacilUsuario");
            //var usuario = JsonConvert.DeserializeObject<LoginModel>(session);

            var usuarios = _context.Login.Select(c => new SelectListItem()
            { Text = c.UserName, Value = c.Id.ToString() });

            ViewBag.UsuariosList = usuarios.ToList();

            if (ModelState.IsValid)
            {
                //projeto.UsuarioId = usuario.Id;
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetoe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var usuarios = _context.Login.Select(c => new SelectListItem()
            { Text = c.UserName, Value = c.Id.ToString() });

            ViewBag.UsuariosList = usuarios.ToList();

            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            var imagens = _context.Imagens.Where(m => m.IdEntidade == projeto.Id && m.TiposEntidades == TiposEntidadesEnum.Projeto).ToList();
            projeto.Imagens = imagens;

            return View(projeto);
        }

        // POST: Projetoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProjeto,UsuarioId,EmailResponsavel,CustoMetro,DataInicio,DataConclusao,UploadProjetos")] ProjetoModel projeto)
        {
            var usuarios = _context.Login.Select(c => new SelectListItem()
            { Text = c.UserName, Value = c.Id.ToString() });

            ViewBag.UsuariosList = usuarios.ToList();

            if (id != projeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (projeto.UploadProjetos != null && projeto.UploadProjetos.Count > 0)
                {
                    foreach (var file in projeto.UploadProjetos)
                    {

                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);


                        Guid guid = Guid.NewGuid();


                        var newFileName = $"{fileName}_{guid}{Path.GetExtension(file.FileName)}";


                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "UploadProjetos");

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }


                        var filePath = Path.Combine(folderPath, newFileName);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var imagemBanco = new ImagensModel();
                        imagemBanco.FilePath = filePath;
                        imagemBanco.TiposEntidades = TiposEntidadesEnum.Projeto;
                        imagemBanco.IdEntidade = projeto.Id;
                        imagemBanco.FileName = newFileName;

                        _context.Imagens.Add(imagemBanco);
                    }

                }

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
                return Redirect("/Projetos/Details/" + projeto.Id);
            }
            return View(projeto);
        }

        // GET: Projetoe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
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
            if (_context.Projeto == null)
            {
                return Problem("Entity set 'Contexto.Projeto_1'  is null.");
            }
            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto != null)
            {
                _context.Projeto.Remove(projeto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return (_context.Projeto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
