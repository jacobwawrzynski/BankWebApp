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
    public class EuroCurrencyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EuroCurrencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EuroCurrency
        public async Task<IActionResult> History()
        {
            var applicationDbContext = _context.EuroAccountHistory;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EuroCurrency/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EuroAccountHistory == null)
                return NotFound();

            var euroAccountHistory = await _context.EuroAccountHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (euroAccountHistory == null)
                return NotFound();

            return View(euroAccountHistory);
        }

        // GET: EuroCurrency/Create
        public IActionResult Transfer()
        {
            ViewData["EuroAccountFK"] = new SelectList(_context.EuroAccounts, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: EuroCurrency/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer([Bind("Id,Title,Amount,Address,Date,Currency,BeneficiaryName,BeneficiaryAccount,EuroAccountFK")] EuroAccountHistory euroAccountHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(euroAccountHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EuroAccountFK"] = new SelectList(_context.EuroAccounts, "AccountNumber", "AccountNumber", euroAccountHistory.EuroAccountFK);
            return View(euroAccountHistory);
        }
    }
}
