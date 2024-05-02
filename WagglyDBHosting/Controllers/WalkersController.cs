using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WagglyDBHosting.Data;
using WagglyDBHosting.Models;

namespace WagglyDBHosting.Controllers
{
    public class WalkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WalkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Walkers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Walkers.ToListAsync());
        }

        // GET: Walkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkers = await _context.Walkers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walkers == null)
            {
                return NotFound();
            }

            return View(walkers);
        }

        // GET: Walkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Walkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Experience,Location,Availability,Mobile")] Walkers walkers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walkers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(walkers);
        }

        // GET: Walkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkers = await _context.Walkers.FindAsync(id);
            if (walkers == null)
            {
                return NotFound();
            }
            return View(walkers);
        }

        // POST: Walkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Experience,Location,Availability,Mobile")] Walkers walkers)
        {
            if (id != walkers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walkers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalkersExists(walkers.Id))
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
            return View(walkers);
        }

        // GET: Walkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkers = await _context.Walkers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walkers == null)
            {
                return NotFound();
            }

            return View(walkers);
        }

        // POST: Walkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walkers = await _context.Walkers.FindAsync(id);
            if (walkers != null)
            {
                _context.Walkers.Remove(walkers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalkersExists(int id)
        {
            return _context.Walkers.Any(e => e.Id == id);
        }
    }
}
