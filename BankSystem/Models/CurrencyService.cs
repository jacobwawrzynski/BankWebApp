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
        /// Adds the amount of dollars to DollarAccount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task DollarDeposit(double amount, string accountNumber)
        {
            var account = await _context.DollarAccounts
                   .Where(da => da.AccountNumber == accountNumber)
                   .FirstOrDefaultAsync();
            account.Funds += amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Shows list of dollar transaction
        /// </summary>
        /// <param name="clientAccount">Account number</param>
        /// <returns></returns>
        public async Task<List<DollarAccountHistory>> DollarHistory(string clientAccount)
        {
            var accountHistory = _context.DollarAccountHistory
                .Where(a => a.BeneficiaryAccount == clientAccount || a.FromAccount == clientAccount);

            return await accountHistory.ToListAsync();
        }

        /// <summary>
        /// Gets transfer data from the form and creates DollarAccountHistory object
        /// </summary>
        /// <param name="transfer"></param>
        /// <param name="dollarAccountHistory"></param>
        /// <returns></returns>
        public async Task DollarTransfer(TransferViewModel transfer, DollarAccountHistory dollarAccountHistory)
        {
            TransferToHistory(transfer, dollarAccountHistory);
            dollarAccountHistory.DollarAccountFK = transfer.FromAccount;
            
            _context.Add(dollarAccountHistory);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Withdraws the amount of dollars
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task DollarWithdrawal(double amount, string accountNumber)
        {
            var account = await _context.DollarAccounts
                    .Where(da => da.AccountNumber == accountNumber)
                    .FirstOrDefaultAsync();
            account.Funds -= amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        
        //Euro Currency

        /// <summary>
        /// Adds the amount of euros to EuroAccount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task EuroDeposit(double amount, string accountNumber)
        {
            var account = await _context.EuroAccounts
                  .Where(ea => ea.AccountNumber == accountNumber)
                  .FirstOrDefaultAsync();
            account.Funds += amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Shows list of euro transaction
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
        /// Gets transfer data from the form and creates EuroAccountHistory object
        /// </summary>
        /// <param name="transfer"></param>
        /// <param name="euroAccountHistory"></param>
        /// <returns></returns>
        public async Task EuroTransfer(TransferViewModel transfer, EuroAccountHistory euroAccountHistory)
        {
            TransferToHistory(transfer, euroAccountHistory);
            euroAccountHistory.EuroAccountFK = transfer.FromAccount;

            _context.Add(euroAccountHistory);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Withdraws the amount of euros
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task EuroWithdrawal(double amount, string accountNumber)
        {
            var account = await _context.EuroAccounts
                   .Where(ea => ea.AccountNumber == accountNumber)
                   .FirstOrDefaultAsync();
            account.Funds -= amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        // Pound Currency

        /// <summary>
        /// Adds the amount of pounds to PoundAccount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task PoundDeposit(double amount, string accountNumber)
        {
            var account = await _context.PoundAccounts
                 .Where(ea => ea.AccountNumber == accountNumber)
                 .FirstOrDefaultAsync();
            account.Funds += amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Shows list of pouns transaction
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<PoundAccountHistory>> PoundHistory(string clientAccount)
        {
            var accountHistory = _context.PoundAccountHistory
                .Where(a => a.BeneficiaryAccount == clientAccount || a.FromAccount == clientAccount);

            return await accountHistory.ToListAsync();
        }

        /// <summary>
        /// Gets transfer data from the form and creates PoundAccountHistory object
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task PoundTransfer(TransferViewModel transfer, PoundAccountHistory poundAccountHistory)
        {
            TransferToHistory(transfer, poundAccountHistory);
            poundAccountHistory.PoundAccountFK = transfer.FromAccount;

            _context.Add(poundAccountHistory);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Withdraws the amount of pounds
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task PoundWithdrawal(double amount, string accountNumber)
        {
            var account = await _context.PoundAccounts
                  .Where(ea => ea.AccountNumber == accountNumber)
                  .FirstOrDefaultAsync();
            account.Funds -= amount;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates IAccountHistory object from TransferViewModel
        /// </summary>
        /// <param name="transfer"></param>
        /// <param name="history"></param>
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
