using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;
using ObraFacilApp.Models.Enum;

namespace ObraFacilApp.Controllers
{
    public class FundacaoController : Controller
    {
        private readonly ContextoModel _context;

        public FundacaoController(ContextoModel context)
        {
            _context = context;
        }

        // GET: Fundacao
        public async Task<IActionResult> Index()
        {
            return _context.Fundacao != null ?
                        View(await _context.Fundacao.ToListAsync()) :
                        Problem("Entity set 'Contexto.Fundacao'  is null.");
        }

        // GET: Fundacao/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Fundacao == null)
            {
                return NotFound();
            }

            var fundacao = await _context.Fundacao
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (fundacao == null)
            {
                return NotFound();
            }

            var imagens = _context.Imagens.Where(m => m.IdEntidade == fundacao.Id && m.TiposEntidades == TiposEntidadesEnum.Fundacao).ToList();
            fundacao.Imagens = imagens;

            return View(fundacao);
        }

        // GET: Fundacao/Create

        public IActionResult Create(int id)
        {
            var FundacaoExistente = _context.Fundacao.FirstOrDefault(m => m.ProjetoId == id);
            if (FundacaoExistente == null)
            {
                ViewBag.ProjetoId = id;
                return View();
            }
            else
            {
                return Redirect("/Fundacao/Details/" + FundacaoExistente.ProjetoId);
            }
        }

        // POST: Fundacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ProjetoId, FundacaoModel fundacao)
        {
            ViewBag.ProjetoId = ProjetoId;
            fundacao.Id = null;
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                _context.Entry(fundacao).State = EntityState.Added;
                _context.Add(fundacao);
                await _context.SaveChangesAsync();
                return Redirect("/Fundacao/Details/" + fundacao.ProjetoId);
            }
            return View(fundacao);
        }

        // GET: Fundacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.Fundacao == null)
            {
                return NotFound();
            }
            var FundacaoExistente = _context.Fundacao.FirstOrDefault(m => m.ProjetoId == id);


            if (FundacaoExistente == null)
            {
                return NotFound();
            }
            var imagens = _context.Imagens.Where(m => m.IdEntidade == FundacaoExistente.Id && m.TiposEntidades == TiposEntidadesEnum.Fundacao).ToList();
            FundacaoExistente.Imagens = imagens;
            return View(FundacaoExistente);

        }

        // POST: Fundacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FundacaoModel fundacao)
        {

            if (id != fundacao.Id)
            {
                return NotFound();
            }

            if (fundacao.UploadFundacao != null && fundacao.UploadFundacao.Count > 0)
            {
                foreach (var file in fundacao.UploadFundacao)
                {

                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);


                    Guid guid = Guid.NewGuid();


                    var newFileName = $"{fileName}_{guid}{Path.GetExtension(file.FileName)}";


                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "UploadFundacao");

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
                    imagemBanco.TiposEntidades = TiposEntidadesEnum.Fundacao;
                    imagemBanco.IdEntidade = fundacao.Id ?? 0;
                    imagemBanco.FileName = newFileName;

                    _context.Imagens.Add(imagemBanco);
                }

            }



            try
            {
                _context.Update(fundacao);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundacaoExists(fundacao.Id ?? 0))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Redirect("/Fundacao/Details/" + fundacao.ProjetoId);

        }

        // GET: Fundacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fundacao == null)
            {
                return NotFound();
            }

            var fundacao = await _context.Fundacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundacao == null)
            {
                return NotFound();
            }

            return View(fundacao);
        }

        // POST: Fundacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fundacao == null)
            {
                return Problem("Entity set 'Contexto.Fundacao'  is null.");
            }
            var fundacao = await _context.Fundacao.FindAsync(id);
            if (fundacao != null)
            {
                _context.Fundacao.Remove(fundacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string caminhoServidor;

        //public FundacaoController (IWebHostEnvironment sistema)
        //{
        //    caminhoServidor = sistema.WebRootPath;
        //}
        //public IActionResult UploadFundacao()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult UploadFundacao(IFormFile imgFundacao)
        //{
        //    string caminhoImagem = caminhoServidor + "\\imagem\\";
        //    string novoNomeImagem = Guid.NewGuid().ToString()+imgFundacao.FileName;
        //    return RedirectToAction("UploadFundacao");
        //}


        private bool FundacaoExists(int id)
        {
            return (_context.Fundacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
