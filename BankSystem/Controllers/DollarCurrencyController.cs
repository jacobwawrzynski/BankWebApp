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
using Microsoft.AspNetCore.Authorization;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Client")]
    public class DollarCurrencyController : Controller, ICurrencyController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrencyService _currencyService;

        public DollarCurrencyController(ApplicationDbContext context, ICurrencyService currencyService)
        {
            _context = context;
            _currencyService = currencyService;
        }

        // GET: DollarCurrency
        public async Task<IActionResult> History()
        {
            var clientAccount = await _context.Clients
                .Where(c => c.Email == User.Identity.Name)
                .Select(c => c.DollarAcc.AccountNumber)
                .FirstOrDefaultAsync();

            return View(await _currencyService.DollarHistory(clientAccount));
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
                var dollarAccount = await _context.DollarAccounts
                    .Where(da => da.AccountNumber == transfer.BeneficiaryAccount)
                    .FirstOrDefaultAsync();

                if (dollarAccount is not null)
                {
                    _currencyService.Transfer(transfer, dollarAccountHistory);
                    dollarAccountHistory.DollarAccountFK = transfer.FromAccount;


                    await Deposit(transfer.Amount, transfer.BeneficiaryAccount);
                    await Withdrawal(transfer.Amount, transfer.FromAccount);

                    _context.Add(dollarAccountHistory);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(History));
                }
                return BadRequest("Incorrect account number");
                
            }
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber", dollarAccountHistory.DollarAccountFK);
            return BadRequest();
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

                await _currencyService.Deposit(amount, account);
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
                await _currencyService.Withdrawal(amount, account);
            }
            return View();
        }
    }
}
