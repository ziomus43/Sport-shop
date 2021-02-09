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
    public class FootballsController : Controller
    {
        private readonly Sport_shopDbContext _context;

        public FootballsController(Sport_shopDbContext context)
        {
            _context = context;
        }

        // GET: Footballs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Footballs.ToListAsync());
        }

        // GET: Footballs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var football = await _context.Footballs
                .FirstOrDefaultAsync(m => m.FootballID == id);
            if (football == null)
            {
                return NotFound();
            }

            return View(football);
        }

        // GET: Footballs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Footballs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FootballID,Name,Price,ProductID")] Football football)
        {
            if (ModelState.IsValid)
            {
                _context.Add(football);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(football);
        }

        public async Task<IActionResult> AddToCart([Bind("BagpackID,Name,Price,ProductID")] Football football,
    Cart cart, int id)
        {
            if (ModelState.IsValid)
            {
                var client_obj = _context.Clients.FirstOrDefault(o => o.Name == "andrzej");
                int client_id = client_obj.ClientID;
                var product_obj = _context.Products.FirstOrDefault(o => o.Name == "Football");
                string name = product_obj.Name;
                int product_id = product_obj.ProductID;
                var football_obj = _context.Footballs.FirstOrDefault(o => o.FootballID == id);
                cart.Quantity = 1;
                cart.Product_Name = name;
                cart.Model_Name = football_obj.Name;
                cart.Price = football_obj.Price;
                cart.ProductID = product_id;
                cart.ClientID = client_id;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Footballs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var football = await _context.Footballs.FindAsync(id);
            if (football == null)
            {
                return NotFound();
            }
            return View(football);
        }

        // POST: Footballs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FootballID,Name,Price,ProductID")] Football football)
        {
            if (id != football.FootballID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(football);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballExists(football.FootballID))
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
            return View(football);
        }

        // GET: Footballs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var football = await _context.Footballs
                .FirstOrDefaultAsync(m => m.FootballID == id);
            if (football == null)
            {
                return NotFound();
            }

            return View(football);
        }

        // POST: Footballs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var football = await _context.Footballs.FindAsync(id);
            _context.Footballs.Remove(football);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballExists(int id)
        {
            return _context.Footballs.Any(e => e.FootballID == id);
        }
    }
}
