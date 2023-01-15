using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankSystem.Data;
using BankSystem.Models;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BankSystem.Controllers
{
    public class PoundCurrencyController : Controller, ICurrencyController
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
            {
                return NotFound();
            }

            var poundAccountHistory = await _context.PoundAccountHistory
                .Include(p => p.PoundAcc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poundAccountHistory == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Transfer([FromForm] TransferViewModel transfer)
        {
            var poundAccountHistory = new PoundAccountHistory();
            if (ModelState.IsValid)
            {
                poundAccountHistory.Title = transfer.Title;
                poundAccountHistory.Amount = transfer.Amount;
                poundAccountHistory.FromAccount = transfer.FromAccount;
                poundAccountHistory.BeneficiaryAccount = transfer.BeneficiaryAccount;
                poundAccountHistory.Address = transfer.Address;
                poundAccountHistory.BeneficiaryName = transfer.BeneficiaryName;
                poundAccountHistory.PoundAccountFK = transfer.FromAccount;

                _context.Add(poundAccountHistory);
                await _context.SaveChangesAsync();

                await Withdrawal(transfer.Amount, transfer.FromAccount);
                await AddMoney(transfer.Amount, transfer.BeneficiaryAccount);

                return RedirectToAction(nameof(History));
            }
            ViewData["PoundAccountFK"] = new SelectList(_context.PoundAccounts, "AccountNumber", "AccountNumber", poundAccountHistory.PoundAccountFK);
            return View(poundAccountHistory);
        }

        public IActionResult AddMoney()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMoney([FromForm] double amount, [FromForm] string accountNumber)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.PoundAccounts
                    .Where(da => da.AccountNumber == accountNumber)
                    .FirstOrDefaultAsync();
                account.Funds += amount;
                _context.Update(account);
                await _context.SaveChangesAsync();
            }
            return View();
        }

        public IActionResult Withdrawal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Withdrawal([FromForm] double amount, [FromForm] string accountNumber)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.PoundAccounts
                    .Where(da => da.AccountNumber == accountNumber)
                    .FirstOrDefaultAsync();
                account.Funds -= amount;
                _context.Update(account);
                await _context.SaveChangesAsync();
            }
            return View();
        }
    }
}
