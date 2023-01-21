using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankSystem.Data;
using BankSystem.Models;
using System.Transactions;
using BankSystem.Models.ViewModels;
using BankSystem.Models.Interfaces;

namespace BankSystem.Controllers
{
    public class DollarCurrencyController : Controller, ICurrencyController
    {
        private readonly ApplicationDbContext _context;

        public DollarCurrencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DollarCurrency
        public async Task<IActionResult> History()
        {
            var clientAccount = _context.Clients.Where(c => c.Email == User.Identity.Name).Select(c => c.DollarAcc.AccountNumber).FirstOrDefault();
            var applicationDbContext = _context.DollarAccountHistory.Where(a => a.BeneficiaryAccount == clientAccount || a.FromAccount == clientAccount);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DollarCurrency
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DollarAccountHistory == null)
                return NotFound();

            var dollarAccountHistory = await _context.DollarAccountHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollarAccountHistory == null)
                return NotFound();

            return View(dollarAccountHistory);
        }

        // GET: DollarCurrency
        public IActionResult Transfer()
        {
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: DollarCurrency
        [HttpPost]
        public async Task<IActionResult> Transfer([FromForm] TransferViewModel transfer)
        {
            var dollarAccountHistory = new DollarAccountHistory();
            if (ModelState.IsValid)
            {
                dollarAccountHistory.Title= transfer.Title;
                dollarAccountHistory.Amount= transfer.Amount;
                dollarAccountHistory.FromAccount= transfer.FromAccount;
                dollarAccountHistory.BeneficiaryAccount = transfer.BeneficiaryAccount;
                dollarAccountHistory.Address = transfer.Address;
                dollarAccountHistory.BeneficiaryName = transfer.BeneficiaryName;
                dollarAccountHistory.DollarAccountFK = transfer.FromAccount;
                
                _context.Add(dollarAccountHistory);
                await _context.SaveChangesAsync();
                
                await Withdrawal(transfer.Amount, transfer.FromAccount);
                await Deposit(transfer.Amount, transfer.BeneficiaryAccount);
                
                return RedirectToAction(nameof(History));
            }
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber", dollarAccountHistory.DollarAccountFK);
            return View(dollarAccountHistory);
        }

        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit([FromForm] double amount, [FromForm] string accountNumber)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.DollarAccounts
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
                var account = await _context.DollarAccounts
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
