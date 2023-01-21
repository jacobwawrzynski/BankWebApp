using BankSystem.Data;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Models
{
    public class CurrencyService : ICurrencyService
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

        public IQueryable<DollarAccountHistory> DollarHistory()
        {
            throw new NotImplementedException();
        }

        public void DollarTransfer(TransferViewModel transfer)
        {
            throw new NotImplementedException();
        }

        public void DollarWithdrawal(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public void EuroDeposit(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EuroAccountHistory> EuroHistory()
        {
            throw new NotImplementedException();
        }

        public void EuroTransfer(TransferViewModel transfer)
        {
            throw new NotImplementedException();
        }

        public void EuroWithdrawal(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public void PoundDeposit(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PoundAccountHistory> PoundHistory()
        {
            throw new NotImplementedException();
        }

        public void PoundTransfer(TransferViewModel transfer)
        {
            throw new NotImplementedException();
        }

        public void PoundWithdrawal(double amount, string accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
