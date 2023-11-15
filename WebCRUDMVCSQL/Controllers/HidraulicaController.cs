using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ObraFacilApp.Models;
using ObraFacilApp.Models.Enum;

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

            var imagens = _context.Imagens.Where(m => m.IdEntidade == hidraulica.Id && m.TiposEntidades == TiposEntidadesEnum.Hidraulica).ToList();
            hidraulica.Imagens = imagens;

            var comentarios = _context.Comentarios.Where(m => m.IdEntidade == hidraulica.Id && m.TiposEntidades == TiposEntidadesEnum.Hidraulica).ToList();
            hidraulica.Comentarios = comentarios;

            var usuarios = _context.Login.ToList();

            foreach (var comentario in hidraulica.Comentarios)
            {
                var usuario = usuarios.Where(x => x.Id == comentario.UsuarioId).FirstOrDefault();
                comentario.UserName = usuario.UserName;
            }

            return View(hidraulica);
        }

        public IActionResult Create([FromRoute] int id)
        {
            var HidraulicaExistente = _context.Hidraulica.FirstOrDefault(m => m.ProjetoId == id);
            if (HidraulicaExistente == null)
            {
                ViewBag.ProjetoId = id;
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
        public async Task<IActionResult> Create(int ProjetoId, HidraulicaModel hidraulica)
        {
            ViewBag.ProjetoId = ProjetoId;

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            hidraulica.Id = null;
            hidraulica.ProjetoId = ProjetoId;

            if (ModelState.IsValid)
            {
                _context.Entry(hidraulica).State = EntityState.Added;
                _context.Add(hidraulica);
                await _context.SaveChangesAsync();
                return Redirect("/Hidraulica/Details/" + hidraulica.ProjetoId);
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

            var hidraulica = await _context.Hidraulica
                           .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (hidraulica == null)
            {
                return NotFound();
            }

            var imagens = _context.Imagens.Where(m => m.IdEntidade == hidraulica.Id && m.TiposEntidades == TiposEntidadesEnum.Hidraulica).ToList();
            hidraulica.Imagens = imagens;

            return View(hidraulica);
        }

        // POST: Hidraulica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HidraulicaModel hidraulica)
        {
            if (id != hidraulica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (hidraulica.UploadHidraulica != null && hidraulica.UploadHidraulica.Count > 0)
                {
                    foreach (var file in hidraulica.UploadHidraulica)
                    {

                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);


                        Guid guid = Guid.NewGuid();


                        var newFileName = $"{fileName}_{guid}{Path.GetExtension(file.FileName)}";


                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "UploadHidraulica");

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
                        imagemBanco.TiposEntidades = TiposEntidadesEnum.Hidraulica;
                        imagemBanco.IdEntidade = hidraulica.Id ?? 0;
                        imagemBanco.FileName = newFileName;

                        _context.Imagens.Add(imagemBanco);
                    }

                }

                try
                {
                    _context.Update(hidraulica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HidraulicaExists(hidraulica.Id ?? 0))
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

        [HttpPost]
        public async Task<IActionResult> SalvarComentario(string entidadeId, string comentario)
        {
            var session = HttpContext.Session.GetString("ObraFacilUsuario");

            if (session == null)
            {
                return RedirectToAction("Index", "Logar");
            }

            var usuario = JsonConvert.DeserializeObject<LoginModel>(session);
            var hidraulica = await _context.Hidraulica.FindAsync(Convert.ToInt32(entidadeId));

            ViewBag.Comentario = comentario;
            var comment = new ComentariosModel()
            {
                TiposEntidades = TiposEntidadesEnum.Hidraulica,
                Texto = comentario,
                IdEntidade = Convert.ToInt32(entidadeId),
                UsuarioId = usuario.Id,
                DataCriacao = DateTime.Now
            };

            _context.Entry(comment).State = EntityState.Added;
            _context.Add(comment);
            await _context.SaveChangesAsync();

            return Redirect("/Hidraulica/Details/" + hidraulica.ProjetoId);
        }

        private bool HidraulicaExists(int id)
        {
          return (_context.Hidraulica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
