﻿using System;
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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Client")]
    public class PoundCurrencyController : Controller, ICurrencyController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrencyService _currencyService;

        public PoundCurrencyController(ApplicationDbContext context, ICurrencyService currencyService)
        {
            _currencyService = currencyService;
            _context = context;
        }

        // GET: PoundCurrency
        public async Task<IActionResult> History()
        {
            var clientAccount = _context.Clients
                .Where(c => c.Email == User.Identity.Name)
                .Select(c => c.PoundAcc.AccountNumber)
                .FirstOrDefault();
            
            return View(await _currencyService.PoundHistory(clientAccount));
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
                await _currencyService.PoundTransfer(transfer, poundAccountHistory);
                await _currencyService.PoundWithdrawal(transfer.Amount, transfer.FromAccount);
                await _currencyService.PoundDeposit(transfer.Amount, transfer.BeneficiaryAccount);

                return RedirectToAction(nameof(History));
            }
            ViewData["PoundAccountFK"] = new SelectList(_context.PoundAccounts, "AccountNumber", "AccountNumber", poundAccountHistory.PoundAccountFK);
            return View(poundAccountHistory);
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
                await _currencyService.PoundDeposit(amount, accountNumber);
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
                await _currencyService.PoundWithdrawal(amount, accountNumber);
            }
            return View();
        }
    }
}
