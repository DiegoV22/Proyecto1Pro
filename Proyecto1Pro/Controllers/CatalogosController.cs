using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto1Pro.Data;
using Proyecto1Pro.Models;

namespace Proyecto1Pro.Controllers
{
    public class CatalogosController : Controller
    {
        private readonly Proyecto1ProContext _context;

        public CatalogosController(Proyecto1ProContext context)
        {
            _context = context;
        }

        // GET: Catalogos
        public async Task<IActionResult> Index()
        {
            var proyecto1ProContext = _context.Catalogo.Include(c => c.Peluche);
            return View(await proyecto1ProContext.ToListAsync());
        }

        // GET: Catalogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .Include(c => c.Peluche)
                .FirstOrDefaultAsync(m => m.IdCatalogo == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return View(catalogo);
        }

        // GET: Catalogos/Create
        public IActionResult Create()
        {
            ViewData["IdPeluche"] = new SelectList(_context.Peluche, "IdPeluche", "IdPeluche");
            return View();
        }

        // POST: Catalogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCatalogo,IdPeluche")] Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPeluche"] = new SelectList(_context.Peluche, "IdPeluche", "IdPeluche", catalogo.IdPeluche);
            return View(catalogo);
        }

        // GET: Catalogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return NotFound();
            }
            ViewData["IdPeluche"] = new SelectList(_context.Peluche, "IdPeluche", "IdPeluche", catalogo.IdPeluche);
            return View(catalogo);
        }

        // POST: Catalogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCatalogo,IdPeluche")] Catalogo catalogo)
        {
            if (id != catalogo.IdCatalogo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoExists(catalogo.IdCatalogo))
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
            ViewData["IdPeluche"] = new SelectList(_context.Peluche, "IdPeluche", "IdPeluche", catalogo.IdPeluche);
            return View(catalogo);
        }

        // GET: Catalogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .Include(c => c.Peluche)
                .FirstOrDefaultAsync(m => m.IdCatalogo == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return View(catalogo);
        }

        // POST: Catalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogo = await _context.Catalogo.FindAsync(id);
            if (catalogo != null)
            {
                _context.Catalogo.Remove(catalogo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoExists(int id)
        {
            return _context.Catalogo.Any(e => e.IdCatalogo == id);
        }
    }
}
