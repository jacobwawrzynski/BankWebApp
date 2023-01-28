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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Client")]
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
                var euroAccount = await _context.EuroAccounts
                    .Where(ea => ea.AccountNumber == transfer.BeneficiaryAccount)
                    .FirstOrDefaultAsync();

                if (euroAccount is not null)
                {
                    _currencyService.Transfer(transfer, euroAccountHistory);
                    euroAccountHistory.EuroAccountFK = transfer.FromAccount;

                    await Deposit(transfer.Amount, transfer.BeneficiaryAccount);
                    await Withdrawal(transfer.Amount, transfer.FromAccount);

                    _context.Add(euroAccountHistory);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(History));
                }
                ViewBag.NullAccount = "Incorrect account number";

            }
            ViewData["EuroAccountFK"] = new SelectList(_context.EuroAccounts, "AccountNumber", "AccountNumber", euroAccountHistory.EuroAccountFK);
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
                var account = await _context.EuroAccounts
                    .Where(ea => ea.AccountNumber== accountNumber)
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
                var account = await _context.EuroAccounts
                   .Where(ea => ea.AccountNumber == accountNumber)
                   .FirstOrDefaultAsync();

                await _currencyService.Withdrawal(amount, account);
            }
            return View();
        }
    }
}
