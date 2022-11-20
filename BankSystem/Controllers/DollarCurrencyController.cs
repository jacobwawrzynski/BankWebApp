using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankSystem.Data;
using BankSystem.Models;

namespace BankSystem.Controllers
{
    public class DollarCurrencyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DollarCurrencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DollarCurrency
        public async Task<IActionResult> History()
        {
            var applicationDbContext = _context.DollarAccountHistory.Include(d => d.DollarAcc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DollarCurrency/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DollarAccountHistory == null)
            {
                return NotFound();
            }

            var dollarAccountHistory = await _context.DollarAccountHistory
                .Include(d => d.DollarAcc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollarAccountHistory == null)
            {
                return NotFound();
            }

            return View(dollarAccountHistory);
        }

        // GET: DollarCurrency/Create
        public IActionResult Transfer()
        {
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: DollarCurrency/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer([Bind("Id,Title,Amount,Date,Currency,BeneficiaryAccount,Address,BeneficiaryName,DollarAccountFK")] DollarAccountHistory dollarAccountHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dollarAccountHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber", dollarAccountHistory.DollarAccountFK);
            return View(dollarAccountHistory);
        }

        // GET: DollarCurrency/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DollarAccountHistory == null)
            {
                return NotFound();
            }

            var dollarAccountHistory = await _context.DollarAccountHistory.FindAsync(id);
            if (dollarAccountHistory == null)
            {
                return NotFound();
            }
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber", dollarAccountHistory.DollarAccountFK);
            return View(dollarAccountHistory);
        }

        // POST: DollarCurrency/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Amount,Date,Currency,BeneficiaryAccount,Address,BeneficiaryName,DollarAccountFK")] DollarAccountHistory dollarAccountHistory)
        {
            if (id != dollarAccountHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dollarAccountHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DollarAccountHistoryExists(dollarAccountHistory.Id))
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
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber", dollarAccountHistory.DollarAccountFK);
            return View(dollarAccountHistory);
        }

        // GET: DollarCurrency/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DollarAccountHistory == null)
            {
                return NotFound();
            }

            var dollarAccountHistory = await _context.DollarAccountHistory
                .Include(d => d.DollarAcc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollarAccountHistory == null)
            {
                return NotFound();
            }

            return View(dollarAccountHistory);
        }

        // POST: DollarCurrency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DollarAccountHistory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DollarAccountHistory'  is null.");
            }
            var dollarAccountHistory = await _context.DollarAccountHistory.FindAsync(id);
            if (dollarAccountHistory != null)
            {
                _context.DollarAccountHistory.Remove(dollarAccountHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DollarAccountHistoryExists(int id)
        {
          return _context.DollarAccountHistory.Any(e => e.Id == id);
        }
    }
}
