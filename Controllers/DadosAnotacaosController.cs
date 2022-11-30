using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhasAnotacoes.Data;
using MinhasAnotacoes.EF;

namespace MinhasAnotacoes.Controllers
{
    public class DadosAnotacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosAnotacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadosAnotacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadosAnotacao.ToListAsync());
        }

        // GET: DadosAnotacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosAnotacao = await _context.DadosAnotacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosAnotacao == null)
            {
                return NotFound();
            }

            return View(dadosAnotacao);
        }

        // GET: DadosAnotacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DadosAnotacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grupo,Cliente,TipoSporte,LocalSuporte,CNPJ,CaminhoPasta,OBS")] DadosAnotacao dadosAnotacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosAnotacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadosAnotacao);
        }

        // GET: DadosAnotacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosAnotacao = await _context.DadosAnotacao.FindAsync(id);
            if (dadosAnotacao == null)
            {
                return NotFound();
            }
            return View(dadosAnotacao);
        }

        // POST: DadosAnotacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grupo,Cliente,TipoSporte,LocalSuporte,CNPJ,CaminhoPasta,OBS")] DadosAnotacao dadosAnotacao)
        {
            if (id != dadosAnotacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosAnotacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosAnotacaoExists(dadosAnotacao.Id))
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
            return View(dadosAnotacao);
        }

        // GET: DadosAnotacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosAnotacao = await _context.DadosAnotacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosAnotacao == null)
            {
                return NotFound();
            }

            return View(dadosAnotacao);
        }

        // POST: DadosAnotacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadosAnotacao = await _context.DadosAnotacao.FindAsync(id);
            _context.DadosAnotacao.Remove(dadosAnotacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosAnotacaoExists(int id)
        {
            return _context.DadosAnotacao.Any(e => e.Id == id);
        }
    }
}
