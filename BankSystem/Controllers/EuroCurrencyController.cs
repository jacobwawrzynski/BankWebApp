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
                euroAccountHistory.Title = transfer.Title;
                euroAccountHistory.Amount = transfer.Amount;
                euroAccountHistory.FromAccount = transfer.FromAccount;
                euroAccountHistory.BeneficiaryAccount = transfer.BeneficiaryAccount;
                euroAccountHistory.Address = transfer.Address;
                euroAccountHistory.BeneficiaryName = transfer.BeneficiaryName;
                euroAccountHistory.EuroAccountFK = transfer.FromAccount;
                
                _context.Add(euroAccountHistory);
                await _context.SaveChangesAsync();

                await Withdrawal(transfer.Amount, transfer.FromAccount);
                await AddMoney(transfer.Amount, transfer.BeneficiaryAccount);

                return RedirectToAction(nameof(History));
            }
            ViewData["EuroAccountFK"] = new SelectList(_context.EuroAccounts, "AccountNumber", "AccountNumber", euroAccountHistory.EuroAccountFK);
            return View(euroAccountHistory);
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
                var account = await _context.EuroAccounts
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
                var account = await _context.EuroAccounts
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
