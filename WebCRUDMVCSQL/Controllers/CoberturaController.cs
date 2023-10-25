using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObraFacilApp.Migrations;
using ObraFacilApp.Models;
using ObraFacilApp.Models.Enum;

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

            var imagens = _context.Imagens.Where(m => m.IdEntidade == cobertura.Id && m.TiposEntidades == TiposEntidadesEnum.Cobertura).ToList();
            cobertura.Imagens = imagens;

            var comentarios = _context.Comentarios.Where(m => m.IdEntidade == cobertura.Id && m.TiposEntidades == TiposEntidadesEnum.Cobertura).ToList();
            cobertura.Comentarios = comentarios;

            var usuarios = _context.Login.ToList();

            foreach (var comentario in cobertura.Comentarios)
            {
                var usuario = usuarios.Where(x => x.Id == comentario.UsuarioId).FirstOrDefault();
                comentario.UserName = usuario.UserName;
            }

            return View(cobertura);
        }

        // GET: Cobertura/Create
        public IActionResult Create([FromRoute] int id)
        {
            var CoberturaExistente = _context.Cobertura.FirstOrDefault(m => m.ProjetoId == id);
            if (CoberturaExistente == null)
            {
                ViewBag.ProjetoId = id;
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
        public async Task<IActionResult> Create(int ProjetoId, CoberturaModel cobertura)
        {
            ViewBag.ProjetoId = ProjetoId;

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            cobertura.Id = null;
            cobertura.ProjetoId = ProjetoId;

            if (ModelState.IsValid)
            {
                _context.Entry(cobertura).State = EntityState.Added;
                _context.Add(cobertura);
                await _context.SaveChangesAsync();
                return Redirect("/Cobertura/Details/" + cobertura.ProjetoId);
            }

            return View(ProjetoId);
        }

        // GET: Cobertura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cobertura == null)
            {
                return NotFound();
            }

            var CoberturaExistente = await _context.Cobertura.FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (CoberturaExistente == null)
            {
                return NotFound();
            }

            var imagens = _context.Imagens.Where(m => m.IdEntidade == CoberturaExistente.Id && m.TiposEntidades == TiposEntidadesEnum.Cobertura).ToList();
            CoberturaExistente.Imagens = imagens;

            return View(CoberturaExistente);
        }

        // POST: Cobertura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CoberturaModel cobertura)
        {
            if (id != cobertura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (cobertura.UploadCobertura != null && cobertura.UploadCobertura.Count > 0)
                {
                    foreach (var file in cobertura.UploadCobertura)
                    {

                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);


                        Guid guid = Guid.NewGuid();


                        var newFileName = $"{fileName}_{guid}{Path.GetExtension(file.FileName)}";


                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "UploadCobertura");

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
                        imagemBanco.TiposEntidades = TiposEntidadesEnum.Cobertura;
                        imagemBanco.IdEntidade = cobertura.Id ?? 0;
                        imagemBanco.FileName = newFileName;

                        _context.Imagens.Add(imagemBanco);
                    }

                }




                try
                {
                    _context.Update(cobertura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoberturaExists(cobertura.Id ?? 0))
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

        [HttpPost]
        public async Task<IActionResult> SalvarComentario(string entidadeId, string comentario)
        {
            var session = HttpContext.Session.GetString("ObraFacilUsuario");

            if (session == null)
            {
                return RedirectToAction("Index", "Logar");
            }
            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);

            ViewBag.Comentario = comentario;
            var comment = new ComentariosModel()
            {
                TiposEntidades = TiposEntidadesEnum.Cobertura,
                Texto = comentario,
                IdEntidade = Convert.ToInt32(entidadeId),
                UsuarioId = usuario.Id,
                DataCriacao = DateTime.Now
            };

            _context.Entry(comment).State = EntityState.Added;
            _context.Add(comment);
            await _context.SaveChangesAsync();

            return Redirect("/Cobertura/Details/" + entidadeId);
        }

        private bool CoberturaExists(int id)
        {
            return (_context.Cobertura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
