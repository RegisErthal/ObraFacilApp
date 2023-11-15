using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObraFacilApp.Migrations;
using ObraFacilApp.Models;
using ObraFacilApp.Models.Enum;

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

            var session = HttpContext.Session.GetString("ObraFacilUsuario");

            if (session == null)
            {
                return RedirectToAction("Index", "Logar");
            }

            var usuarioLogado = JsonConvert.DeserializeObject<LoginModel>(session);

            eletrica.UsuarioLogado = usuarioLogado;

            var imagens = _context.Imagens.Where(m => m.IdEntidade == eletrica.Id && m.TiposEntidades == TiposEntidadesEnum.Eletrica).ToList();
            eletrica.Imagens = imagens;

            var comentarios = _context.Comentarios.Where(m => m.IdEntidade == eletrica.Id && m.TiposEntidades == TiposEntidadesEnum.Eletrica).ToList();
            eletrica.Comentarios = comentarios;

            var usuarios = _context.Login.ToList();

            foreach (var comentario in eletrica.Comentarios)
            {
                var usuario = usuarios.Where(x => x.Id == comentario.UsuarioId).FirstOrDefault();
                comentario.UserName = usuario.UserName;
            }

            return View(eletrica);
        }

        // GET: Eletrica/Create
        public IActionResult Create([FromRoute] int id)
        {
            var EletricaExistente = _context.Eletrica.FirstOrDefault(m => m.ProjetoId == id);
            if (EletricaExistente == null)
            {
                ViewBag.ProjetoId = id;
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
        public async Task<IActionResult> Create([FromRoute] int id, EletricaModel eletrica)
        {
            ViewBag.ProjetoId = id;

            eletrica.Id = null;

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            //eletrica.ProjetoId = ProjetoId;
            if (ModelState.IsValid)
            {
                _context.Entry(eletrica).State = EntityState.Added;
                _context.Add(eletrica);
                await _context.SaveChangesAsync();
                return Redirect("/Eletrica/Details/" + eletrica.ProjetoId);
            }
            return View(eletrica);
        }

        // GET: Eletrica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eletrica == null)
            {
                return NotFound();
            }

            var EletricaExistente = await _context.Eletrica.FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (EletricaExistente == null)
            {
                return NotFound();
            }

            var imagens = _context.Imagens.Where(m => m.IdEntidade == EletricaExistente.Id && m.TiposEntidades == TiposEntidadesEnum.Eletrica).ToList();
            EletricaExistente.Imagens = imagens;

            return View(EletricaExistente);
        }

        // POST: Eletrica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EletricaModel eletrica)

        {
            if (id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (eletrica.UploadEletrica != null && eletrica.UploadEletrica.Count > 0)
                {
                    foreach (var file in eletrica.UploadEletrica)
                    {

                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);


                        Guid guid = Guid.NewGuid();


                        var newFileName = $"{fileName}_{guid}{Path.GetExtension(file.FileName)}";


                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "UploadEletrica");

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
                        imagemBanco.TiposEntidades = TiposEntidadesEnum.Eletrica;
                        imagemBanco.IdEntidade = eletrica.Id ?? 0;
                        imagemBanco.FileName = newFileName;

                        _context.Imagens.Add(imagemBanco);
                    }

                }

                try
                {
                    _context.Update(eletrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EletricaExists(eletrica.Id ?? 0))
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

        [HttpPost]
        public async Task<IActionResult> SalvarComentario(string entidadeId, string comentario)
        {
            var session = HttpContext.Session.GetString("ObraFacilUsuario");

            if (session == null)
            {
                return RedirectToAction("Index", "Logar");
            }

            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);
            var eletrica = await _context.Eletrica.FindAsync(Convert.ToInt32(entidadeId));

            ViewBag.Comentario = comentario;
            var comment = new ComentariosModel()
            {
                TiposEntidades = TiposEntidadesEnum.Eletrica,
                Texto = comentario,
                IdEntidade = Convert.ToInt32(entidadeId),
                UsuarioId = usuario.Id,
                DataCriacao = DateTime.Now
            };

            _context.Entry(comment).State = EntityState.Added;
            _context.Add(comment);
            await _context.SaveChangesAsync();

            return Redirect("/Eletrica/Details/" + eletrica.ProjetoId);
        }

        public async Task<IActionResult> ApagarComentario(string id)
        {
            var comment = await _context.Comentarios.FindAsync(Convert.ToInt32(id));
            var eletrica = await _context.Eletrica.FindAsync(comment.IdEntidade);

            _context.Entry(comment).State = EntityState.Deleted;
            _context.Remove(comment);
            _context.SaveChanges();

            return Redirect("/Eletrica/Details/" + eletrica.ProjetoId);
        }

        private bool EletricaExists(int id)
        {
            return (_context.Eletrica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
