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
    public class PoundCurrencyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoundCurrencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoundCurrency
        public async Task<IActionResult> History()
        {
            var applicationDbContext = _context.PoundAccountHistory;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PoundCurrency/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PoundAccountHistory == null)
                return NotFound();

            var poundAccountHistory = await _context.PoundAccountHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poundAccountHistory == null)
                return NotFound();

            return View(poundAccountHistory);
        }

        // GET: PoundCurrency/Create
        public IActionResult Transfer()
        {
            ViewData["PoundAccountFK"] = new SelectList(_context.PoundAccounts, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: PoundCurrency/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer([Bind("Id,Title,Amount,Date,Currency,BeneficiaryAccount,Address,BeneficiaryName,PoundAccountFK")] PoundAccountHistory poundAccountHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poundAccountHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoundAccountFK"] = new SelectList(_context.PoundAccounts, "AccountNumber", "AccountNumber", poundAccountHistory.PoundAccountFK);
            return View(poundAccountHistory);
        }

    }
}
