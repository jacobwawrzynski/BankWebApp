using BankSystem.Data;
using BankSystem.Models.ViewModels;

namespace BankSystem.Models.Interfaces
{
    public interface ICurrencyService
    {
        public IAccountHistory Transfer(TransferViewModel transfer, IAccountHistory history);
        public Task Deposit(double amount, IAccount account);
        public Task Withdrawal(double amount, IAccount account);
        
        public Task<List<DollarAccountHistory>> DollarHistory(string clientAccount);
        public Task<List<EuroAccountHistory>> EuroHistory(string clientAccount);
        public Task<List<PoundAccountHistory>> PoundHistory(string clientAccount);
    }
}
