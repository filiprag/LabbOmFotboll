using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabbOmFotboll.Models;

namespace LabbOmFotboll.Controllers
{
    public class FotbollspelaresController : Controller
    {
        private readonly DbModel _context;

        public FotbollspelaresController(DbModel context)
        {
            _context = context;
        }

        // GET: Fotbollspelares
        public async Task<IActionResult> Index()
        {
            var dbModel = _context.Fotbollspelares.Include(f => f.Lag);
            return View(await dbModel.ToListAsync());
        }

        public async Task<IActionResult> LagOchSpelare(int? Id)
        {
            var dbModel = _context.Fotbollspelares.Include(a => a.Lag).Where(b => b.LagId == Id);
            return View(await dbModel.ToListAsync());
        }

        // GET: Fotbollspelares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotbollspelare = await _context.Fotbollspelares
                .Include(f => f.Lag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotbollspelare == null)
            {
                return NotFound();
            }

            return View(fotbollspelare);
        }

        // GET: Fotbollspelares/Create
        public IActionResult Create()
        {
            ViewData["LagId"] = new SelectList(_context.Lags, "Id", "lagNamn");
            //ViewData["LagId"] = new SelectList(_context.Lags, nameof(Lag.Id), nameof(Lag.lagNamn)); Ger samma resultat som ovan
            return View();
        }

        // POST: Fotbollspelares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn,Langd,Vikt,LagId")] Fotbollspelare fotbollspelare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotbollspelare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LagId"] = new SelectList(_context.Lags, "Id", "Id", fotbollspelare.LagId);
            return View(fotbollspelare);
        }

        // GET: Fotbollspelares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotbollspelare = await _context.Fotbollspelares.FindAsync(id);
            if (fotbollspelare == null)
            {
                return NotFound();
            }
            ViewData["LagId"] = new SelectList(_context.Lags, "Id", "lagNamn", fotbollspelare.LagId);
            return View(fotbollspelare);
        }

        // POST: Fotbollspelares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn,Langd,Vikt,LagId")] Fotbollspelare fotbollspelare)
        {
            if (id != fotbollspelare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotbollspelare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotbollspelareExists(fotbollspelare.Id))
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
            ViewData["LagId"] = new SelectList(_context.Lags, "Id", "Id", fotbollspelare.LagId);
            return View(fotbollspelare);
        }

        // GET: Fotbollspelares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotbollspelare = await _context.Fotbollspelares
                .Include(f => f.Lag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotbollspelare == null)
            {
                return NotFound();
            }

            return View(fotbollspelare);
        }

        // POST: Fotbollspelares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotbollspelare = await _context.Fotbollspelares.FindAsync(id);
            _context.Fotbollspelares.Remove(fotbollspelare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotbollspelareExists(int id)
        {
            return _context.Fotbollspelares.Any(e => e.Id == id);
        }
    }
}
