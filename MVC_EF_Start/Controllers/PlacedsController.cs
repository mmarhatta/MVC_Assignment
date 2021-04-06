using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class PlacedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Placeds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Places.Include(p => p.PlacedOrder).Include(p => p.PlacedProduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Placeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placed = await _context.Places
                .Include(p => p.PlacedOrder)
                .Include(p => p.PlacedProduct)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (placed == null)
            {
                return NotFound();
            }

            return View(placed);
        }

        // GET: Placeds/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID");
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID");
            return View();
        }

        // POST: Placeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductID,OrderID,PlacedDate")] Placed placed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", placed.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID", placed.ProductID);
            return View(placed);
        }

        // GET: Placeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placed = await _context.Places.SingleOrDefaultAsync(m => m.ID == id);
            if (placed == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", placed.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID", placed.ProductID);
            return View(placed);
        }

        // POST: Placeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductID,OrderID,PlacedDate")] Placed placed)
        {
            if (id != placed.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacedExists(placed.ID))
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
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", placed.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ID", "ID", placed.ProductID);
            return View(placed);
        }

        // GET: Placeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placed = await _context.Places
                .Include(p => p.PlacedOrder)
                .Include(p => p.PlacedProduct)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (placed == null)
            {
                return NotFound();
            }

            return View(placed);
        }

        // POST: Placeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placed = await _context.Places.SingleOrDefaultAsync(m => m.ID == id);
            _context.Places.Remove(placed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacedExists(int id)
        {
            return _context.Places.Any(e => e.ID == id);
        }
    }
}
