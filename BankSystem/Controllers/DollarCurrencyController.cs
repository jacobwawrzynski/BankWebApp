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
        private readonly ICurrencyService _currencyService;

        public DollarCurrencyController(ApplicationDbContext context, ICurrencyService currencyService)
        {
            _context = context;
            _currencyService = currencyService;
        }

        // GET: DollarCurrency
        public async Task<IActionResult> History()
        {
            var clientAccount = _context.Clients
                .Where(c => c.Email == User.Identity.Name)
                .Select(c => c.DollarAcc.AccountNumber)
                .FirstOrDefault();

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
                await _currencyService.DollarTransfer(transfer, dollarAccountHistory);
                await _currencyService.DollarWithdrawal(transfer.Amount, transfer.FromAccount);
                await _currencyService.DollarDeposit(transfer.Amount, transfer.BeneficiaryAccount);
                return RedirectToAction(nameof(History));
            }
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber", dollarAccountHistory.DollarAccountFK);
            return View();
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
                await _currencyService.DollarDeposit(amount, accountNumber);
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
                await _currencyService.DollarWithdrawal(amount, accountNumber);
            }
            return View();
        }
    }
}
