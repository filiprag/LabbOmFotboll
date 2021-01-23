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
    public class LagsController : Controller
    {
        private readonly DbModel _context;

        public LagsController(DbModel context)
        {
            _context = context;
        }

        // GET: Lags
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lags.ToListAsync());
        }

        // GET: Lags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lag = await _context.Lags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lag == null)
            {
                return NotFound();
            }

            return View(lag);
        }

        // GET: Lags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,lagNamn")] Lag lag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lag);
        }

        // GET: Lags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lag = await _context.Lags.FindAsync(id);
            if (lag == null)
            {
                return NotFound();
            }
            return View(lag);
        }

        // POST: Lags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,lagNamn")] Lag lag)
        {
            if (id != lag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LagExists(lag.Id))
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
            return View(lag);
        }

        // GET: Lags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lag = await _context.Lags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lag == null)
            {
                return NotFound();
            }

            return View(lag);
        }

        // POST: Lags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lag = await _context.Lags.FindAsync(id);
            _context.Lags.Remove(lag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LagExists(int id)
        {
            return _context.Lags.Any(e => e.Id == id);
        }
    }
}
