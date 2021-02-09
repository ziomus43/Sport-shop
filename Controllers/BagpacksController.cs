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
    public class BagpacksController : Controller
    {
        
        private readonly Sport_shopDbContext _context;

        public BagpacksController(Sport_shopDbContext context)
        {
            _context = context;
        }

        // GET: Bagpacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bagpacks.ToListAsync());
        }

        // GET: Bagpacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagpack = await _context.Bagpacks
                .FirstOrDefaultAsync(m => m.BagpackID == id);
            if (bagpack == null)
            {
                return NotFound();
            }

            return View(bagpack);
        }

        // GET: Bagpacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bagpacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BagpackID,Name,Price,ProductID")] Bagpack bagpack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bagpack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bagpack);
        }

        public async Task<IActionResult> AddToCart([Bind("BagpackID,Name,Price,ProductID")] Bagpack bagpack,
            Cart cart, int id)
        {
            if (ModelState.IsValid)
            {
                var client_obj = _context.Clients.FirstOrDefault(o => o.Name == "andrzej");
                int client_id = client_obj.ClientID;
                var product_obj = _context.Products.FirstOrDefault(o => o.Name == "Bagpack");
                string name = product_obj.Name;
                int product_id = product_obj.ProductID;
                var bagpack_obj = _context.Bagpacks.FirstOrDefault(o => o.BagpackID == id);
                cart.Quantity = 1;
                cart.Product_Name = name;
                cart.Model_Name = bagpack_obj.Name;
                cart.Price = bagpack_obj.Price;
                cart.ProductID = product_id;
                cart.ClientID = client_id;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Bagpacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagpack = await _context.Bagpacks.FindAsync(id);
            if (bagpack == null)
            {
                return NotFound();
            }
            return View(bagpack);
        }

        // POST: Bagpacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BagpackID,Name,Price,ProductID")] Bagpack bagpack)
        {
            if (id != bagpack.BagpackID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bagpack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagpackExists(bagpack.BagpackID))
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
            return View(bagpack);
        }

        // GET: Bagpacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagpack = await _context.Bagpacks
                .FirstOrDefaultAsync(m => m.BagpackID == id);
            if (bagpack == null)
            {
                return NotFound();
            }

            return View(bagpack);
        }

        // POST: Bagpacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bagpack = await _context.Bagpacks.FindAsync(id);
            _context.Bagpacks.Remove(bagpack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BagpackExists(int id)
        {
            return _context.Bagpacks.Any(e => e.BagpackID == id);
        }
    }
}
