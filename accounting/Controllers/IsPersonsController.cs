using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using accounting.Models;

namespace accounting.Controllers
{
    public class IsPersonsController : Controller
    {
        private readonly AccountDBContex _context;

        public IsPersonsController(AccountDBContex context)
        {
            _context = context;
        }

        // GET: IsPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.IsPeople.ToListAsync());
        }

        // GET: IsPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isPerson = await _context.IsPeople
                .FirstOrDefaultAsync(m => m.ID == id);
            if (isPerson == null)
            {
                return NotFound();
            }

            return View(isPerson);
        }

        // GET: IsPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IsPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDperson,IDproduct")] IsPerson isPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isPerson);
        }

        // GET: IsPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isPerson = await _context.IsPeople.FindAsync(id);
            if (isPerson == null)
            {
                return NotFound();
            }
            return View(isPerson);
        }

        // POST: IsPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDperson,IDproduct")] IsPerson isPerson)
        {
            if (id != isPerson.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsPersonExists(isPerson.ID))
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
            return View(isPerson);
        }

        // GET: IsPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isPerson = await _context.IsPeople
                .FirstOrDefaultAsync(m => m.ID == id);
            if (isPerson == null)
            {
                return NotFound();
            }

            return View(isPerson);
        }

        // POST: IsPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isPerson = await _context.IsPeople.FindAsync(id);
            _context.IsPeople.Remove(isPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IsPersonExists(int id)
        {
            return _context.IsPeople.Any(e => e.ID == id);
        }
    }
}
