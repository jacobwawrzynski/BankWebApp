using BankSystem.Data;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace BankSystem.Models
{
    public class CurrencyService : Controller, ICurrencyService
    {
        private readonly ApplicationDbContext _context;
        public CurrencyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DollarDeposit(double amount, string accountNumber)
        {
            var account = await _context.DollarAccounts
                   .Where(da => da.AccountNumber == accountNumber)
                   .FirstOrDefaultAsync();
            account.Funds += amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DollarAccountHistory>> DollarHistory(string clientAccount)
        {
            var accountHistory = _context.DollarAccountHistory
                .Where(a => a.BeneficiaryAccount == clientAccount || a.FromAccount == clientAccount);

            return await accountHistory.ToListAsync();
        }

        public async Task DollarTransfer(TransferViewModel transfer, DollarAccountHistory dollarAccountHistory)
        {
            TransferToHistory(transfer, dollarAccountHistory);
            dollarAccountHistory.DollarAccountFK = transfer.FromAccount;
            
            _context.Add(dollarAccountHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DollarWithdrawal(double amount, string accountNumber)
        {
            var account = await _context.DollarAccounts
                    .Where(da => da.AccountNumber == accountNumber)
                    .FirstOrDefaultAsync();
            account.Funds -= amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task TransferTest()
        {
            ViewData["DollarAccountFK"] = new SelectList(_context.DollarAccounts, "AccountNumber", "AccountNumber");
        }

        public async Task EuroDeposit(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EuroAccountHistory>> EuroHistory()
        {
            throw new NotImplementedException();
        }

        public async Task EuroTransfer(TransferViewModel transfer)
        {
            throw new NotImplementedException();
        }

        public async Task EuroWithdrawal(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task PoundDeposit(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PoundAccountHistory>> PoundHistory()
        {
            throw new NotImplementedException();
        }

        public async Task PoundTransfer(TransferViewModel transfer)
        {
            throw new NotImplementedException();
        }

        public async Task PoundWithdrawal(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public void TransferToHistory(TransferViewModel transfer, IAccountHistory history)
        {
            history.Title = transfer.Title;
            history.Amount = transfer.Amount;
            history.FromAccount = transfer.FromAccount;
            history.BeneficiaryAccount = transfer.BeneficiaryAccount;
            history.Address = transfer.Address;
            history.BeneficiaryName = transfer.BeneficiaryName;
        }
    }
}
