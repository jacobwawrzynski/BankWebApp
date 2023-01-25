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


        // Dollar Currency
        /// <summary>
        /// Shows list of dollar transactions
        /// </summary>
        /// <param name="clientAccount">Account number</param>
        /// <returns></returns>
        public async Task<List<DollarAccountHistory>> DollarHistory(string clientAccount)
        {
            var history = _context.DollarAccountHistory
                .Where(a => a.BeneficiaryAccount == clientAccount || a.FromAccount == clientAccount);

            return await history.ToListAsync();
        }

        // Pound Currency
        /// <summary>
        /// Shows list of pouns transactions
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<PoundAccountHistory>> PoundHistory(string clientAccount)
        {
            var accountHistory = _context.PoundAccountHistory
                .Where(a => a.BeneficiaryAccount == clientAccount || a.FromAccount == clientAccount);

            return await accountHistory.ToListAsync();
        }

        // Euro Currency
        /// <summary>
        /// Shows list of euro transactions
        /// </summary>
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        public async Task<List<EuroAccountHistory>> EuroHistory(string clientAccount)
        {
            var accountHistory = _context.EuroAccountHistory
                .Where(a => a.BeneficiaryAccount == clientAccount || a.FromAccount == clientAccount);

            return await accountHistory.ToListAsync();
        }

        /// <summary>
        /// Adds the amount of currency to IAccount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task Deposit(double amount, IAccount account)
        {
            account.Funds += amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        

        /// <summary>
        /// Gets transfer data from the form and creates IAccountHistory object
        /// </summary>
        /// <param name="transfer"></param>
        /// <param name="history"></param>
        /// <returns></returns>
        public IAccountHistory Transfer(TransferViewModel transfer, IAccountHistory history)
        {
            history.Title = transfer.Title;
            history.Amount = transfer.Amount;
            history.FromAccount = transfer.FromAccount;
            history.BeneficiaryAccount = transfer.BeneficiaryAccount;
            history.Address = transfer.Address;
            history.BeneficiaryName = transfer.BeneficiaryName;

            return history;
        }

        /// <summary>
        /// Withdraws the amount of currency
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task Withdrawal(double amount, IAccount account)
        {
            account.Funds -= amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
