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
    public class PeluchesController : Controller
    {
        private readonly Proyecto1ProContext _context;

        public PeluchesController(Proyecto1ProContext context)
        {
            _context = context;
        }

        // GET: Peluches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peluche.ToListAsync());
        }

        // GET: Peluches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peluche = await _context.Peluche
                .FirstOrDefaultAsync(m => m.IdPeluche == id);
            if (peluche == null)
            {
                return NotFound();
            }

            return View(peluche);
        }

        // GET: Peluches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peluches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeluche,NombreP,Precio,Tamano,Categoria")] Peluche peluche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peluche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peluche);
        }

        // GET: Peluches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peluche = await _context.Peluche.FindAsync(id);
            if (peluche == null)
            {
                return NotFound();
            }
            return View(peluche);
        }

        // POST: Peluches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeluche,NombreP,Precio,Tamano,Categoria")] Peluche peluche)
        {
            if (id != peluche.IdPeluche)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peluche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelucheExists(peluche.IdPeluche))
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
            return View(peluche);
        }

        // GET: Peluches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peluche = await _context.Peluche
                .FirstOrDefaultAsync(m => m.IdPeluche == id);
            if (peluche == null)
            {
                return NotFound();
            }

            return View(peluche);
        }

        // POST: Peluches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peluche = await _context.Peluche.FindAsync(id);
            if (peluche != null)
            {
                _context.Peluche.Remove(peluche);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelucheExists(int id)
        {
            return _context.Peluche.Any(e => e.IdPeluche == id);
        }
    }
}
