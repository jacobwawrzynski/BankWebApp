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
            var applicationDbContext = _context.TransferHistory;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DollarCurrency
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransferHistory == null)
                return NotFound();

            var dollarAccountHistory = await _context.TransferHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dollarAccountHistory == null)
                return NotFound();

            return View(dollarAccountHistory);
        }

        // GET: DollarCurrency
        public IActionResult Transfer()
        {
            //ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: DollarCurrency
        [HttpPost]
        public async Task<IActionResult> Transfer([FromForm] TransferViewModel transfer)
        {
            if (ModelState.IsValid)
            {
                var transferHistory = new TransferHistory()
                {
                    Amount= transfer.Amount,
                    Date= transfer.Date,
                    Title= transfer.Title,
                    BeneficiaryName= transfer.BeneficiaryName,
                    BeneficiaryAccountNumber = transfer.BeneficiaryAccountNumber,
                    FromAccountNumber = transfer.FromAccountNumber,
                    Address = transfer.Address,
                    Currency= transfer.Currency,
                };
                _context.Add(transferHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(History));
            }
            return View(transfer);
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
