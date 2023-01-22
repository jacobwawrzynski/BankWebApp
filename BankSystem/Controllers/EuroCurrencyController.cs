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

namespace BankSystem.Controllers
{
    public class EuroCurrencyController : Controller, ICurrencyController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrencyService _currencyService;

        public EuroCurrencyController(ApplicationDbContext context, ICurrencyService currencyService)
        {
            _context = context;
            _currencyService = currencyService;
        }

        // GET: EuroCurrency
        public async Task<IActionResult> History()
        {
            var clientAccount = _context.Clients
                .Where(c => c.Email == User.Identity.Name)
                .Select(c => c.EuroAcc.AccountNumber)
                .FirstOrDefault();

            return View(await _currencyService.EuroHistory(clientAccount));
        }

        // GET: EuroCurrency/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EuroAccountHistory == null)
            {
                return NotFound();
            }

            var euroAccountHistory = await _context.EuroAccountHistory
                .Include(e => e.EuroAcc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (euroAccountHistory == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Transfer([FromForm] TransferViewModel transfer)
        {
            var euroAccountHistory = new EuroAccountHistory();
            if (ModelState.IsValid)
            {
                await _currencyService.EuroTransfer(transfer, euroAccountHistory);
                await _currencyService.EuroWithdrawal(transfer.Amount, transfer.FromAccount);
                await _currencyService.EuroDeposit(transfer.Amount, transfer.BeneficiaryAccount);

                return RedirectToAction(nameof(History));
            }
            ViewData["EuroAccountFK"] = new SelectList(_context.EuroAccounts, "AccountNumber", "AccountNumber", euroAccountHistory.EuroAccountFK);
            return View(euroAccountHistory);
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
                await _currencyService.EuroDeposit(amount, accountNumber);
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
                await _currencyService.EuroWithdrawal(amount, accountNumber);
            }
            return View();
        }
    }
}
