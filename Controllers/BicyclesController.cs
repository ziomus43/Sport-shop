using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sport_shop.Data;
using Sport_shop.Models;

namespace Sport_shop.Controllers
{
    public class BicyclesController : Controller
    {
        private readonly Sport_shopDbContext _context;

        public BicyclesController(Sport_shopDbContext context)
        {
            _context = context;
        }

        // GET: Bicycles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bicycles.ToListAsync());
        }

        // GET: Bicycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycles
                .FirstOrDefaultAsync(m => m.BicycleID == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // GET: Bicycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BicycleID,Name,Price,ProductID")] Bicycle bicycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicycle);
        }

        public async Task<IActionResult> AddToCart([Bind("BagpackID,Name,Price,ProductID")] Bicycle bicycle,
            Cart cart, int id)
        {
            if (ModelState.IsValid)
            {
                var client_obj = _context.Clients.FirstOrDefault(o => o.Name == "andrzej");
                int client_id = client_obj.ClientID;
                var product_obj = _context.Products.FirstOrDefault(o => o.Name == "Bicycle");
                string name = product_obj.Name;
                int product_id = product_obj.ProductID;
                var bicycle_obj = _context.Bicycles.FirstOrDefault(o => o.BicycleID == id);
                cart.Quantity = 1;
                cart.Product_Name = name;
                cart.Model_Name = bicycle_obj.Name;
                cart.Price = bicycle_obj.Price;
                cart.ProductID = product_id;
                cart.ClientID = client_id;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Bicycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycles.FindAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }
            return View(bicycle);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BicycleID,Name,Price,ProductID")] Bicycle bicycle)
        {
            if (id != bicycle.BicycleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleExists(bicycle.BicycleID))
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
            return View(bicycle);
        }

        // GET: Bicycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycles
                .FirstOrDefaultAsync(m => m.BicycleID == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicycle = await _context.Bicycles.FindAsync(id);
            _context.Bicycles.Remove(bicycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleExists(int id)
        {
            return _context.Bicycles.Any(e => e.BicycleID == id);
        }
    }
}
